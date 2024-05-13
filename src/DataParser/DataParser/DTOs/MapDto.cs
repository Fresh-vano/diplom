using Newtonsoft.Json;

namespace DataParser.DTOs
{
	public class MapGeneralDto
	{
		[JsonProperty("total")]
		public TotalDto Total { get; set; }

		[JsonProperty("results")]
		public List<MapDto> Maps { get; set; }
	}

	public class MapDto
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("match_id")]
		public int MatchID { get; set; }

		[JsonProperty("begin_at")]
		public DateTimeOffset BeginAt { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("map_name")]
		public string MapName { get; set; }

		[JsonProperty("winner_clan_score")]
		public int WinnerScore { get; set; }

		[JsonProperty("loser_clan_score")]
		public int LoserScore { get; set; }

		[JsonProperty("winner_team_clan")]
		public NestedTeamDto WinnerTeam { get; set; }

		[JsonProperty("loser_team_clan")]
		public NestedTeamDto LoserTeam { get; set; }

		[JsonProperty("number")]
		public int Number { get; set; }

		[JsonProperty("rounds_count")]
		public int RoundCount { get; set; }

		public class NestedTeamDto
		{
			[JsonProperty("id")]
			public int Id { get; set; }
		}
	}
}
