using System;
using FluxBandcampIntegration.Models;
using Newtonsoft.Json;

namespace FluxBandcampIntegration.Clients
{
	public class BandcampClient
	{

        private readonly HttpClient _client;
        const string url = "https://bandcamp.com/oauth_token";

        public BandcampClient()
		{
            _client = new HttpClient();
		}

        public async Task<AuthorizationToken> FetchBandcampToken(HttpContent content)
        { 
            

            var httpContent = new FormUrlEncodedContent(formData);
            var response = await _client.PostAsync(url, httpContent, CancellationToken.None);
            var stringContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AuthorizationToken>(stringContent);

        }
    }
}

