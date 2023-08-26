using FluxBandcampIntegration.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FluxBandcampIntegration.Controllers
{ 
    [ApiController]
    [Route("[controller]/[action]")]
    public class DebugEndpoints : Controller
    {
        private readonly AuthorizationService _authService;

        public DebugEndpoints(AuthorizationService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public async Task<string> TestBCAuth()
        {
            var token = await _authService.GetAuthorizationToken();

            return JsonConvert.SerializeObject(token);
        }

        [HttpPost(Name = "GetSalesByBandId")]
        public async Task<string> GetSalesByBandId()
        {
            var token = await _authService.GetAuthorizationToken();



            return JsonConvert.SerializeObject(token);
        }
    }
}

