using DataAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace DataAPI.Controllers
{
	[Route("api/data/match")]
	public class MatchController : ControllerBase
	{
		private readonly Cs2Context _context;

		public MatchController(Cs2Context context)
		{
			_context = context;
		}

		[HttpGet("finished")]
		public IActionResult GetFinishedMatches()
		{
			var matches = _context.Matches
								  .Where(m => m.EndDate < DateTime.UtcNow)
								  .ToList();
			return Ok(new { matches });
		}

		[HttpGet("current")]
		public IActionResult GetCurrentMatches()
		{
			var matches = _context.Matches
								  .Where(m => m.StartDate <= DateTime.UtcNow && m.EndDate >= DateTime.UtcNow)
								  .ToList();
			return Ok(new { matches });
		}

		[HttpGet("{slug}")]
		public IActionResult GetMatchBySlug(string slug)
		{
			var match = _context.Matches
								.FirstOrDefault(m => m.Slug == slug);
			if (match == null) return NotFound();
			return Ok(new { match });
		}

		[HttpGet("{slug}/stats")]
		public IActionResult GetMatchStats(string slug)
		{
			// Placeholder: Implement statistics retrieval logic
			return Ok(new { statistics = "Match statistics data" });
		}

		[HttpGet("{slug}/stats/{mapName}")]
		public IActionResult GetMatchStatsByMap(string slug, string mapName)
		{
			// Placeholder: Implement map-specific statistics retrieval logic
			return Ok(new { statistics = "Map-specific statistics data" });
		}
	}
}
