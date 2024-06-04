using System;
using System.Collections.Generic;

namespace DataSearch.Models;

public partial class Map
{
    public int Id { get; set; }

    public int MatchId { get; set; }

    public DateTime BeginAt { get; set; }

    public int Status { get; set; }

    public int MapName { get; set; }

    public int WinnerScore { get; set; }

    public int LoserScore { get; set; }

    public int WinnerId { get; set; }

    public int LoserId { get; set; }

    public int Number { get; set; }

    public int RoundCount { get; set; }

    public int Discipline { get; set; }

    public string? DemoName { get; set; }

    public virtual Team Loser { get; set; } = null!;

    public virtual Match Match { get; set; } = null!;

    public virtual ICollection<PlayerMetric> PlayerMetrics { get; set; } = new List<PlayerMetric>();

    public virtual ICollection<PlayerResultMetric> PlayerResultMetrics { get; set; } = new List<PlayerResultMetric>();

    public virtual ICollection<PlayerStat> PlayerStats { get; set; } = new List<PlayerStat>();

    public virtual ICollection<RoundTeamMetric> RoundTeamMetrics { get; set; } = new List<RoundTeamMetric>();

    public virtual ICollection<Round> Rounds { get; set; } = new List<Round>();

    public virtual ICollection<TeamResultMetric> TeamResultMetrics { get; set; } = new List<TeamResultMetric>();

    public virtual Team Winner { get; set; } = null!;
}
