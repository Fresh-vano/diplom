using DataSearch.DTOs;

namespace DataSearch.Repository
{
	public interface IPlayerRepository
	{
		public List<PlayerSearchDto> SearchPlayers(string query);
	}
}
