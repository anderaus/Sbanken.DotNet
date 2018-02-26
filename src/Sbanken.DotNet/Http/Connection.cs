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
        private const string TokenEndpointUrl = "https://api.sbanken.no/identityserver/connect/token";

        private bool _disposed;

        private readonly HttpClient _httpClient;
        private readonly TokenClient _tokenClient;

        public Connection(string clientId, string clientSecret)
        {
            _tokenClient = new TokenClient(TokenEndpointUrl, clientId, clientSecret)
            {
                BasicAuthenticationHeaderStyle = TokenClient.AuthenticationHeaderStyle.Rfc2617
            };

            var accessTokenHandler = new AccessTokenHandler(
                _tokenClient,
                scope: null);

            _httpClient = new HttpClient(accessTokenHandler)
            {
                BaseAddress = new Uri(ApiBaseUrl)
            };
        }

        public async Task<T> Get<T>(string relativeUrl, IDictionary<string, string> parameters = null)
        {
            if (parameters != null)
            {
                relativeUrl = string.Concat(relativeUrl, "?", GetParametersQuery(parameters));
            }

            var response = await _httpClient.GetAsync(relativeUrl);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }

        public async Task<NoResult> Post(string relativeUrl, object body)
        {
            var content = new StringContent(
                JsonConvert.SerializeObject(body),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync(relativeUrl, content);
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