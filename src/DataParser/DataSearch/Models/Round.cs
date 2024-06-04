using System;
using System.Collections.Generic;

namespace DataSearch.Models;

public partial class Round
{
    public int Id { get; set; }

    public int EndReason { get; set; }

    public int MapId { get; set; }

    public int RoundNumber { get; set; }

    public int LoserTeamScore { get; set; }

    public int LoserTeamSide { get; set; }

    public int LoserTeamId { get; set; }

    public int WinnerTeamScore { get; set; }

    public int WinnerTeamSide { get; set; }

    public int WinnerTeamId { get; set; }

    public int Team1MetricId { get; set; }

    public int Team2MetricId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Team LoserTeam { get; set; } = null!;

    public virtual Map Map { get; set; } = null!;

    public virtual ICollection<RoundPlayerMetric> RoundPlayerMetrics { get; set; } = new List<RoundPlayerMetric>();

    public virtual RoundTeamMetric? RoundTeamMetricRound { get; set; }

    public virtual ICollection<RoundTeamMetric> RoundTeamMetricRoundId1Navigations { get; set; } = new List<RoundTeamMetric>();

    public virtual RoundTeamMetric Team1Metric { get; set; } = null!;

    public virtual Team WinnerTeam { get; set; } = null!;
}
