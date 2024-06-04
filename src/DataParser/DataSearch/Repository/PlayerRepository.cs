using DataSearch.Data;
using DataSearch.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataSearch.Repository
{
	public class PlayerRepository : IPlayerRepository
	{
		private readonly Cs2Context _context;

		public PlayerRepository(Cs2Context context)
		{
			_context = context;
		}

		public List<PlayerSearchDto> SearchPlayers(string query)
		{
			return _context.Players
						   .Where(p => EF.Functions.ToTsVector("russian", p.Nickname + " " + p.FirstName + " " + p.LastName)
									  .Matches(EF.Functions.PlainToTsQuery("russian", query)))
						   //.OrderByDescending(p => EF.Functions.TsRank(EF.Functions.ToTsVector("russian", p.Nickname + " " + p.FirstName + " " + p.LastName), EF.Functions.PlainToTsQuery("russian", query)))
						   .Take(5)
						   .Select(p => new PlayerSearchDto { Id = p.Id, Nickname = p.Nickname })
						   .ToList();
		}
	}
}
