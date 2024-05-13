using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DataParser.DTOs
{
	public class TeamRosterDto
	{
		[JsonProperty("players")]
		public List<PlayerDto> Players { get; set; }
	}
}
