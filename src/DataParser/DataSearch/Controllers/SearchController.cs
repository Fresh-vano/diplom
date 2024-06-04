using DataSearch.DTOs;
using DataSearch.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DataSearch.Controllers
{
	[Route("api/[controller]")]
	public class SearchController : ControllerBase
	{
		private readonly IPlayerRepository _playerRepository;
		private readonly ITeamRepository _teamRepository;
		private readonly ITournamentRepository _tournamentRepository;

		public SearchController(IPlayerRepository playerRepository, ITeamRepository teamRepository, ITournamentRepository tournamentRepository)
		{
			_playerRepository = playerRepository;
			_teamRepository = teamRepository;
			_tournamentRepository = tournamentRepository;
		}

		public SearchResult Search(string query)
		{
			var players = _playerRepository.SearchPlayers(query);
			var teams = _teamRepository.SearchTeams(query);
			var tournaments = _tournamentRepository.SearchTournaments(query);

			return new SearchResult
			{
				Players = players,
				Teams = teams,
				Tournaments = tournaments
			};
		}
	}
}
