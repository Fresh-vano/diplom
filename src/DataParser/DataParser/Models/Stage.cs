using DataParser.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataParser.Models
{
	public class Stage
	{
		[Key]
		public int Id { get; set; }

		public TournamentStatusEnum Status { get; set; }

		public string Title { get; set; } = string.Empty;

		[ForeignKey("Tournament")]
		public int TournamentId { get; set; }
		
		public Tournament? Tournament { get; set; }

		public List<Team>? Teams { get; set; }

		public StageTypeEnum StageType { get; set; }

		public List<Match>? Matches { get; set; }

		public string? Description { get; set; }
	}
}
