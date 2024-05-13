using DataParser.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataParser.Models
{
	public class Map
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey("Match")]
		public int MatchID { get; set; }

		public Match? Match { get; set; }

		public DateTimeOffset BeginAt { get; set; }

		public MapStatusEnum Status { get; set; }

		public MapNameEnum MapName { get; set; }

		public int WinnerScore { get; set; }

		public int LoserScore { get; set; }

		[ForeignKey("Winner")]
		public int WinnerId { get; set; }

		public Team? Winner {  get; set; }

		[ForeignKey("Loser")]
		public int LoserId { get; set; }

		public Team? Loser { get; set; }

		public int Number {  get; set; }

		public int RoundCount { get; set; }

		public DisciplineEnum Discipline { get; set; }

		public List<PlayerMetric>? PlayerMetrics { get; set; }

		public List<PlayerResultMetric>? PlayerResultMetrics { get; set; }

		public List<Round>? Rounds { get; set; }

		public string? DemoName { get; set; }
	}
}
