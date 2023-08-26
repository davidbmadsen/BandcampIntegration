using FluxBandcampIntegration.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FluxBandcampIntegration.Controllers
{ 
    [ApiController]
    [Route("[controller]")]
    public class DebugEndpoints : Controller
    {
        private readonly AuthorizationService _authService;

        public DebugEndpoints(AuthorizationService authService)
        {
            _authService = authService;
        }

        [HttpGet(Name = "getAuthorizationToken")]
        public async Task<string> TestBCAuth()
        {
            var token = await _authService.GetAuthorizationToken();

            return JsonConvert.SerializeObject(token);
        }

        [HttpGet(Name = "getAuthorizationToken")]
        public async Task<string> TestBCAuth2()
        {
            var token = await _authService.GetAuthorizationToken();

            return JsonConvert.SerializeObject(token);
        }

    }
}

