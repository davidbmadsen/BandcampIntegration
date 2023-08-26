using FluxBandcampIntegration.Clients;
using FluxBandcampIntegration.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace FluxBandcampIntegration.Services
{
    public class AuthorizationService
    {
        private readonly IConfiguration _config;
        private readonly IMemoryCache _cache;
        private readonly BandcampClient _bandcampClient;

        public AuthorizationService(IConfiguration config, IMemoryCache cache, BandcampClient bandcampClient)
        {
            _config = config;
            _cache = cache;
            _bandcampClient = bandcampClient;
        }

        public async Task<string> GetAuthorizationToken()
        {
            if (!_cache.TryGetValue("TOKEN", out string authToken))
            {
                var payload = new FormUrlEncodedContent(new Dictionary<string, string>
                { 
                    {"client_id", _config.GetValue<string>("Authorization:ClientId")},
                    {"client_secret",  _config.GetValue<string>("Authorization:ClientSecret")},
                    {"grant_type", "client_credentials"}
                });

                var authTokenModel = await _bandcampClient.FetchBandcampToken(payload);

                var options = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(
                              TimeSpan.FromSeconds(authTokenModel.ExpiresIn));

                _cache.Set("TOKEN", authTokenModel.AccessToken, options);

                authToken = authTokenModel.AccessToken;
            }

            return authToken;
        }
    }
}

