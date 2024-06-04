using DataAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace DataAPI.Controllers
{
	[Route("api/data/team")]
	public class TeamController : ControllerBase
	{
		private readonly Cs2Context _context;

		public TeamController(Cs2Context context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetAllTeams()
		{
			var teams = _context.Teams.ToList();
			return Ok(new { teams });
		}

		[HttpGet("{slug}")]
		public IActionResult GetTeamBySlug(string slug)
		{
			var team = _context.Teams.FirstOrDefault(t => t.Slug == slug);
			if (team == null) return NotFound();
			return Ok(new { team });
		}
	}
}
