using DataAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace DataAPI.Controllers
{
	[Route("api/data/player")]
	public class PlayerController : ControllerBase
	{
		private readonly Cs2Context _context;

		public PlayerController(Cs2Context context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetAllPlayers()
		{
			var players = _context.Players.ToList();
			return Ok(new { players });
		}

		[HttpGet("{slug}")]
		public IActionResult GetPlayerBySlug(string slug)
		{
			var player = _context.Players.FirstOrDefault(p => p.Slug == slug);
			if (player == null) return NotFound();
			return Ok(new { player });
		}
	}
}
