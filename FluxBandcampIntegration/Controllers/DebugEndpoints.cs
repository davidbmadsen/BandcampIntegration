using FluxBandcampIntegration.Clients;
using FluxBandcampIntegration.Models.Requests;
using FluxBandcampIntegration.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FluxBandcampIntegration.Controllers
{ 
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DebugEndpoints : Controller
    {
        private readonly AuthorizationService _authService;
        private readonly BandcampClient _bandcampClient;

        public DebugEndpoints(AuthorizationService authService, BandcampClient bandcampClient)
        {
            _authService = authService;
            _bandcampClient = bandcampClient;
        }

        [HttpGet]
        public async Task<string> TestBCAuth()
        {
            var token = await _authService.GetAuthorizationToken();

            return JsonConvert.SerializeObject(token);
        }

        [HttpPost(Name = "getSales")]
        public async Task<string> GetSales([FromBody] SalesRequest salesRequest)
        {
            var token = await _authService.GetAuthorizationToken();

            var response = await _bandcampClient.GetSalesByRequest(salesRequest, token);

            string resp = JsonConvert.SerializeObject(response,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return response;
        }
    }
}

