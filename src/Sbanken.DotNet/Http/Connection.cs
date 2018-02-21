using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Net.Http;
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
            // Switch to regular TokenClient when this issue is fixed in the Sbanken API: https://github.com/Sbanken/api-examples/issues/11
            _tokenClient = new CustomTokenClient(TokenEndpointUrl, clientId, clientSecret);

            var accessTokenHandler = new AccessTokenHandler(
                _tokenClient,
                scope: null);

            _httpClient = new HttpClient(accessTokenHandler)
            {
                BaseAddress = new Uri(ApiBaseUrl)
            };
        }

        public async Task<T> Get<T>(string relativeUrl)
        {
            var response = await _httpClient.GetAsync(relativeUrl);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
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