using Newtonsoft.Json;

namespace DataParser.DTOs
{

	public class MatchMinDto
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("slug")]
		public string Slug { get; set; }

		[JsonProperty("team1_id")]
		public int Team1Id { get; set; }

		[JsonProperty("team2_id")]
		public int Team2Id { get; set; }

		[JsonProperty("team1_score")]
		public int Team1Score { get; set; }

		[JsonProperty("team2_score")]
		public int Team2Score { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("start_date")]
		public DateTimeOffset? StartDate { get; set; }

		[JsonProperty("end_date")]
		public DateTimeOffset? EndDate { get; set; }

		[JsonProperty("bo_type")]
		public int BOType { get; set; }

		[JsonProperty("parsed_status")]
		public string ParsedStatus { get; set; }

		[JsonProperty("tournament")]
		public NestedTournamentDto NestedTournament { get; set; }

		public class NestedTournamentDto
		{
			[JsonProperty("id")]
			public int Id { get; set; }
		}
	}
}
