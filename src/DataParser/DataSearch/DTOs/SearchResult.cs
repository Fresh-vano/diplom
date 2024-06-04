namespace DataSearch.DTOs
{
	public class SearchResult
	{
		public List<PlayerSearchDto> Players { get; set; }
		public List<TeamSearchDto> Teams { get; set; }
		public List<TournamentSearchDto> Tournaments { get; set; }
	}
}
