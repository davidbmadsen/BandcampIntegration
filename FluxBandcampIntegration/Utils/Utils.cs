using AutoMapper;
using FluxBandcampIntegration.Models.Requests;

namespace FluxBandcampIntegration.Utils
{
	public static class Utils
	{
		public static IMapper CreateMapper()
		{
            var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<SalesRequest, BandcampSalesRequest>());
            return mapperConfig.CreateMapper();
        }
	}
}

