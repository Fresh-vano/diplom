using DataSearch.DTOs;

namespace DataSearch.Repository
{
	public interface ITournamentRepository
	{
		public List<TournamentSearchDto> SearchTournaments(string query);
	}
}
