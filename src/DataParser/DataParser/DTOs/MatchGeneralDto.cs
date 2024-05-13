using Newtonsoft.Json;

namespace DataParser.DTOs
{
	public class MatchGeneralDto
	{
		[JsonProperty("total")]
		public TotalDto Total { get; set; }

		[JsonProperty("results")]
		public List<MatchMinDto> MatchtMin { get; set; }
	}
}
