using DataParser.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataParser.Models
{
	public class Round : BaseModel
	{
		[Key]
		public int Id { get; set; }

		public EndReasonEnum EndReason { get; set; }

		[ForeignKey("Map")]
		public int MapId { get; set; }

		public Map? Map { get; set; }

		public int RoundNumber { get; set; }

		public int LoserTeamScore { get; set; }

		public SideEnum LoserTeamSide { get; set; }

		[ForeignKey("LoserTeam")]
		public int LoserTeamId { get; set; }

		public Team? LoserTeam { get; set; }

		public int WinnerTeamScore { get; set; }

		public SideEnum WinnerTeamSide { get; set; }

		[ForeignKey("WinnerTeam")]
		public int WinnerTeamId { get; set; }

		public Team? WinnerTeam { get; set; }

		[ForeignKey("Team1Metric")]
		public int Team1MetricId { get; set; }
		public RoundTeamMetric? Team1Metric { get; set; }

		[ForeignKey("Team2Metric")]
		public int Team2MetricId { get; set; }
		public RoundTeamMetric? Team2Metric { get; set; }

		public List<RoundPlayerMetric>? RoundPlayerMetrics { get; set; }
	}
}
