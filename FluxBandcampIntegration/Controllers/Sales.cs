using FluxBandcampIntegration.Clients;
using FluxBandcampIntegration.Models.Requests;
using FluxBandcampIntegration.Services;
using Microsoft.AspNetCore.Mvc;

namespace FluxBandcampIntegration.Controllers
{ 
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class Sales : Controller
    {
        private readonly AuthorizationService _authService;
        private readonly BandcampClient _bandcampClient;

        public Sales(AuthorizationService authService, BandcampClient bandcampClient)
        {
            _authService = authService;
            _bandcampClient = bandcampClient;
        }

        [HttpPost(Name = "getSalesByRequest")]
        public async Task<string> GetSales([FromBody] SalesRequest salesRequest)
        {
            var token = await _authService.GetAuthorizationToken();

            return await _bandcampClient.GetSalesByRequest(salesRequest, token);
        }

        
        public async Task<string> GetSalesByArtist(string artistName)
        {
            var token = await _authService.GetAuthorizationToken();

            // Get artist names

            // Check if one of them is a match with artistName

            // If yes, query the sales API with the band_id

            // If no, return 400
        }
    }
}

