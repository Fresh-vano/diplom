using DataAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace DataAPI.Controllers
{
	[Route("api/data/tournament")]
	public class TournamentController : ControllerBase
	{
		private readonly Cs2Context _context;

		public TournamentController(Cs2Context context)
		{
			_context = context;
		}

		[HttpGet("current")]
		public IActionResult GetCurrentTournaments()
		{
			var tournaments = _context.Tournaments.Where(t => t.StartDate >= DateTime.UtcNow).ToList();
			return Ok(new { tournaments });
		}

		[HttpGet("finished")]
		public IActionResult GetFinishedTournaments()
		{
			var tournaments = _context.Tournaments.Where(t => t.EndDate < DateTime.UtcNow).ToList();
			return Ok(new { tournaments });
		}

		[HttpGet("{slug}")]
		public IActionResult GetTournamentBySlug(string slug)
		{
			var tournament = _context.Tournaments.FirstOrDefault(t => t.Slug == slug);

			if (tournament == null)
				return NotFound();

			return Ok(new { tournament });
		}
	}
}
