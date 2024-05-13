using System.Text.Json.Serialization;
using Newtonsoft.Json;
namespace DataParser.DTOs
{
	public class TeamGeneralDTO
	{
		[JsonProperty("total")]
		public TotalDto Total { get; set; }

		[JsonProperty("results")]
		public List<TeamRankDto> TeamRanks { get; set; }
	}
}
