using Newtonsoft.Json;

namespace DataParser.DTOs
{
	public class TournamentGeneralDto
	{
		[JsonProperty("total")]
		public TotalDto Total { get; set; }

		[JsonProperty("results")]
		public List<TournamentMinDto> TournamentMin { get; set; }
	}
}
