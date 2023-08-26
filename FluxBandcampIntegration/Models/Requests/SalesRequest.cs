namespace FluxBandcampIntegration.Models.Requests
{
	public class SalesRequest
	{
		public long BandId { get; set; }
		public long MemberBandId { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public string Format { get; set; } = "json";
	}
}

