using FluxBandcampIntegration.Models;
using FluxBandcampIntegration.Models.Requests;
using Newtonsoft.Json;

namespace FluxBandcampIntegration.Clients
{
	public class BandcampClient : BaseClient
    {

        public async Task<AuthorizationToken> FetchBandcampToken(HttpContent requestPayload)
        { 
            return JsonConvert.DeserializeObject<AuthorizationToken>(await SendRequest(requestPayload, HttpMethod.Post));
        }

        public async Task<string> GetSalesByBandId(SalesRequest salesRequest, string token)
        {
            var content = StringContentify(salesRequest);

            return await SendRequest(content, HttpMethod.Post, token);
        }
    }
}

