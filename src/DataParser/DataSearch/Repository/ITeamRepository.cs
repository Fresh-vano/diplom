using DataSearch.DTOs;

namespace DataSearch.Repository
{
	public interface ITeamRepository
	{
		public List<TeamSearchDto> SearchTeams(string query);
	}
}
