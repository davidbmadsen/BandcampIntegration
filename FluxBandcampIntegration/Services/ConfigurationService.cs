using System;
namespace FluxBandcampIntegration.Services
{
	public class ConfigurationService
	{
		private readonly IConfiguration _config;

        public ConfigurationService(IConfiguration config)
		{
			_config = config;
		}

		public void Validate()
		{
			throw new NotImplementedException();
		}
	}
}

