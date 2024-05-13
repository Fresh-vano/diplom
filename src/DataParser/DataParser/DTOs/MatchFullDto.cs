using Newtonsoft.Json;

namespace DataParser.DTOs
{
	public class MatchFullDto
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("winner_team_id")]
		public int WinnerTeamId { get; set; }

		[JsonProperty("loser_team_id")]
		public int LoserTeamId { get; set; }

		[JsonProperty("tournament_id")]
		public int TournamentID { get; set; }
	}
}
