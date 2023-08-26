using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace FluxBandcampIntegration.Clients
{
	public class BaseClient
	{
        private readonly HttpClient _client;
        const string url = "https://bandcamp.com/oauth_token";

        public BaseClient()
        {
            _client = new HttpClient();
        }

        protected async Task<string> SendRequest(HttpContent requestContent,HttpMethod httpMethod, string? token = null)
        {
            using var requestMessage = new HttpRequestMessage(httpMethod, url);

            requestMessage.Content = requestContent;

            if (token != null)
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.SendAsync(requestMessage);

            return await response.Content.ReadAsStringAsync();
        }

        protected static HttpContent StringContentify<T>(T content)
        {
            return new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
        }
    }
}

