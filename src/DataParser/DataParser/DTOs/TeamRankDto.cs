using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DataParser.DTOs
{
	public class TeamRankDto
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("team_id")]
		public int TeamId { get; set; }

		[JsonProperty("team_roster_id")]
		public int TeamRosterId { get; set; }

		[JsonProperty("current")]
		public bool? Current { get; set; }

		[JsonProperty("top_tier")]
		public bool? TopTier { get; set; }

		[JsonProperty("six_month_value")]
		public int? SixMonthValue { get; set; }

		[JsonProperty("six_month_tour_wins")]
		public int? SixMonthTourWins { get; set; }

		[JsonProperty("curr_year_value")]
		public int? CurrYearValue { get; set; }

		[JsonProperty("curr_year_tour_wins")]
		public int? CurrYearTourWins { get; set; }

		[JsonProperty("rank")]
		public int Rank { get; set; }

		[JsonProperty("date")]
		public DateTime? Date { get; set; }

		[JsonProperty("created_at")]
		public DateTime? CreatedAt { get; set; }

		[JsonProperty("updated_at")]
		public DateTime? UpdatedAt { get; set; }

		[JsonProperty("team")]
		public TeamDto Team { get; set; }

		[JsonProperty("team_roster")]
		public TeamRosterDto TeamRoster { get; set; }
	}
}
