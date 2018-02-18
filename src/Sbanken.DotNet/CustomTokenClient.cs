using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sbanken.DotNet
{
    internal class CustomTokenClient : TokenClient
    {
        public CustomTokenClient(string address, string clientId, string clientSecret)
            : base(address, clientId, clientSecret) { }

        public override async Task<TokenResponse> RequestAsync(IDictionary<string, string> form,
            CancellationToken cancellationToken = new CancellationToken())
        {
            HttpResponseMessage response;

            var request = new HttpRequestMessage(HttpMethod.Post, Address)
            {
                Content = new FormUrlEncodedContent(form)
            };

            request.Headers.Authorization = new BasicAuthenticationHeaderValue(ClientId, ClientSecret);

            try
            {
                response = await Client.SendAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return new TokenResponse(ex);
            }

            string content = null;
            if (response.Content != null)
            {
                content = await response.Content.ReadAsStringAsync();
            }

            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return new TokenResponse(content);
            }

            return new TokenResponse(response.StatusCode, response.ReasonPhrase, content);
        }
    }
}