using Newtonsoft.Json;

namespace FluxBandcampIntegration.Models.Requests
{
	public class BandcampSalesRequest
	{
		[JsonProperty("band_id")]
		public long BandId { get; set; }
		[JsonProperty("member_band_id")]
		public long MemberBandId { get; set; }
		[JsonProperty("start_time")]
		public DateTime StartTime { get; set; }
		[JsonProperty("end_time")]
		public DateTime EndTime { get; set; }
		[JsonProperty("format")]
		public string Format { get; set; }
	}
}

