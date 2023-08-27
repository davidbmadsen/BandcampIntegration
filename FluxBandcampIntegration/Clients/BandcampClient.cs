using AutoMapper;
using FluxBandcampIntegration.Models;
using FluxBandcampIntegration.Models.Requests;
using Newtonsoft.Json;

namespace FluxBandcampIntegration.Clients
{
	public class BandcampClient : BaseClient
    {
        public BandcampClient(IMapper mapper) : base(mapper)
        {
        }

        public async Task<AuthorizationToken> FetchBandcampToken(HttpContent requestPayload)
        { 
            return JsonConvert.DeserializeObject<AuthorizationToken>(await SendRequest(requestPayload, path: "oauth_token", HttpMethod.Post));
        }

        public async Task<string> GetSalesByRequest(SalesRequest salesRequest, string token)
        {
            var content = CreateRequestBody<SalesRequest, BandcampSalesRequest>(salesRequest);

            return await SendRequest(content, path: "api/sales/2/sales_report", HttpMethod.Post, token);
        }
    }
}

