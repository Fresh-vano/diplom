using Newtonsoft.Json;

namespace DataParser.DTOs
{
	public class TeamClanDto
	{
		[JsonProperty("clan_name")]
		public string ClanName { get; set; }

		[JsonProperty("team_id")]
		public int TeamId { get; set; }

		[JsonProperty("id")]
		public int Id { get; set; }
	}
}
