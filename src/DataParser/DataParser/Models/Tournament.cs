using System.ComponentModel.DataAnnotations;
using DataParser.Enums;

namespace DataParser.Models
{
	public class Tournament : BaseModel
	{
		[Key]
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string Slug { get; set; } = string.Empty;

		public TournamentStatusEnum Status { get; set; }

		public TierEnum Tier { get; set; }

		public DateTimeOffset StartDate { get; set; }

		public DateTimeOffset EndDate { get; set; }

		public int Prize { get; set; }

		public EventTypeEnum? EventType { get; set; }

		public string? Description { get; set; }

		public DisciplineEnum? Discipline { get; set; }

		public string? ImageUrl { get; set; }

		public Country? Country { get; set; }

		public List<Team>? Teams { get; set; }

		public List<Stage>? Stages { get; set; }
	}
}
