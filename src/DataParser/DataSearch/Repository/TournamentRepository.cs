using DataSearch.Data;
using DataSearch.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataSearch.Repository
{
	public class TournamentRepository : ITournamentRepository
	{
		private readonly Cs2Context _context;

		public TournamentRepository(Cs2Context context)
		{
			_context = context;
		}

		public List<TournamentSearchDto> SearchTournaments(string query)
		{
			return _context.Tournaments
						   .Where(t => EF.Functions.ToTsVector("russian", t.Name)
									  .Matches(EF.Functions.PlainToTsQuery("russian", query)))
						   //.OrderByDescending(t => EF.Functions.TsRank(EF.Functions.ToTsVector("russian", t.Name), EF.Functions.PlainToTsQuery("russian", query)))
						   .Take(5)
						   .Select(t => new TournamentSearchDto { Id = t.Id, Name = t.Name })
						   .ToList();
		}
	}
}
