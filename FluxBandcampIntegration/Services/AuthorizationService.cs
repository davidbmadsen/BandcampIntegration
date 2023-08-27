using FluxBandcampIntegration.Clients;
using Microsoft.Extensions.Caching.Memory;
namespace FluxBandcampIntegration.Services
{
    public class AuthorizationService
    {
        private readonly IConfiguration _config;
        private readonly IMemoryCache _cache;
        private readonly BandcampClient _bandcampClient;
        private readonly string clientId;
        private readonly string clientSecret;

        public AuthorizationService(IConfiguration config, IMemoryCache cache, BandcampClient bandcampClient)
        {
            _config = config;
            _cache = cache;
            _bandcampClient = bandcampClient;
            clientId = _config.GetValue<string>("Authorization:ClientId")
                       ?? throw new ArgumentNullException($"{nameof(clientId)}");
            clientSecret = _config.GetValue<string>("Authorization:ClientSecret")
                           ?? throw new ArgumentNullException($"{nameof(clientId)}");

        }

        public async Task<string> GetAuthorizationToken()
        {
            if (!_cache.TryGetValue("TOKEN", out string authToken))
            {
                var payload = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"client_id", clientId},
                    {"client_secret", clientSecret},
                    {"grant_type", "client_credentials"}
                });

                var authTokenModel = await _bandcampClient.FetchBandcampToken(payload);

                if (authTokenModel.TokenType == null)
                    throw new Exception("Too many token requests have been made. Try again later.");

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

