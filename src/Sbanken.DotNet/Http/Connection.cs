using IdentityModel.Client;
using Newtonsoft.Json;
using Sbanken.DotNet.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sbanken.DotNet.Http
{
    public class Connection : IConnection
    {
        private const string ApiBaseUrl = "https://api.sbanken.no/";
        private const string TokenEndpointUrl = "https://auth.sbanken.no/identityserver/connect/token";

        private bool _disposed;

        private readonly HttpClient _httpClient;
        private readonly TokenClient _tokenClient;

        public Connection(string clientId, string clientSecret)
        {
            _tokenClient = new TokenClient(TokenEndpointUrl, clientId, clientSecret)
            {
                BasicAuthenticationHeaderStyle = BasicAuthenticationHeaderStyle.Rfc6749
            };

            var accessTokenDelegatingHandler = new AccessTokenDelegatingHandler(
                _tokenClient,
                scope: null,
                innerHandler: new HttpClientHandler());

            _httpClient = new HttpClient(accessTokenDelegatingHandler)
            {
                BaseAddress = new Uri(ApiBaseUrl)
            };
        }

        public async Task<T> Get<T>(string relativeUrl, string customerId, IDictionary<string, string> parameters = null)
        {
            if (parameters != null)
            {
                relativeUrl = string.Concat(relativeUrl, "?", GetParametersQuery(parameters));
            }

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, relativeUrl);
            requestMessage.Headers.Add("customerId", customerId);
            var response = await _httpClient.SendAsync(requestMessage);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }

        public async Task<NoResult> Post(string relativeUrl, string customerId, object body)
        {
            var content = new StringContent(
                JsonConvert.SerializeObject(body),
                Encoding.UTF8,
                "application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, relativeUrl);
            requestMessage.Headers.Add("customerId", customerId);
            requestMessage.Content = content;
            var response = await _httpClient.SendAsync(requestMessage);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<NoResult>(responseContent);
        }

        private static string GetParametersQuery(IDictionary<string, string> parameters)
        {
            return string.Join("&", parameters.Select(kvp => kvp.Key + "=" + Uri.EscapeDataString(kvp.Value)));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _tokenClient.Dispose();
                _httpClient.Dispose();
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}