using AutoMapper;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace FluxBandcampIntegration.Clients
{
	public class BaseClient
	{
        private readonly HttpClient _client;
        private readonly IMapper _mapper;
        const string url = "https://bandcamp.com/";

        public BaseClient(IMapper mapper)
        {
            _client = new HttpClient();
            _mapper = mapper;
        }

        protected async Task<string> SendRequest(HttpContent requestContent, string path, HttpMethod httpMethod,string? token = null)
        {
            using var requestMessage = new HttpRequestMessage(httpMethod, url + path);

            requestMessage.Content = requestContent;

            if (token != null)
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.SendAsync(requestMessage);

            return await response.Content.ReadAsStringAsync();
        }

        protected HttpContent CreateRequestBody<TIn, TRequest>(TIn content)
        {
            var requestContent = _mapper.Map<TIn, TRequest>(content);

            return new StringContent(JsonConvert.SerializeObject(requestContent), Encoding.UTF8, "application/json");
        }
    }
}

