using DataSearch.Data;
using DataSearch.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataSearch.Repository
{
	public class TeamRepository : ITeamRepository
	{
		private readonly Cs2Context _context;

		public TeamRepository(Cs2Context context)
		{
			_context = context;
		}

		public List<TeamSearchDto> SearchTeams(string query)
		{
			return _context.Teams
						   .Where(t => EF.Functions.ToTsVector("russian", t.Name + " " + t.Acronym)
									  .Matches(EF.Functions.PlainToTsQuery("russian", query)))
						   //.OrderByDescending(t => EF.Functions.TsRank(EF.Functions.ToTsVector("russian", t.Name + " " + t.Acronym), EF.Functions.PlainToTsQuery("russian", query)))
						   .Take(5)
						   .Select(t => new TeamSearchDto { Id = t.Id, Name = t.Name, Slug = t.Slug })
						   .ToList();
		}
	}
}
