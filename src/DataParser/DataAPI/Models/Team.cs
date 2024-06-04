using System;
using System.Collections.Generic;

namespace DataAPI.Models;

public partial class Team
{
    public int Id { get; set; }

    public string Slug { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Acronym { get; set; }

    public int? CountryId { get; set; }

    public string? IconUrl { get; set; }

    public string? WebsiteUrl { get; set; }

    public string? YoutubeUrl { get; set; }

    public int? StageId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Map> MapLosers { get; set; } = new List<Map>();

    public virtual ICollection<Map> MapWinners { get; set; } = new List<Map>();

    public virtual ICollection<Match> MatchLoserTeams { get; set; } = new List<Match>();

    public virtual ICollection<Match> MatchTeam1s { get; set; } = new List<Match>();

    public virtual ICollection<Match> MatchTeam2s { get; set; } = new List<Match>();

    public virtual ICollection<Match> MatchWinnerTeams { get; set; } = new List<Match>();

    public virtual ICollection<PlayerStat> PlayerStats { get; set; } = new List<PlayerStat>();

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

    public virtual ICollection<Round> RoundLoserTeams { get; set; } = new List<Round>();

    public virtual ICollection<RoundTeamMetric> RoundTeamMetrics { get; set; } = new List<RoundTeamMetric>();

    public virtual ICollection<Round> RoundWinnerTeams { get; set; } = new List<Round>();

    public virtual Stage? Stage { get; set; }

    public virtual ICollection<TeamName> TeamNames { get; set; } = new List<TeamName>();

    public virtual ICollection<TeamResultMetric> TeamResultMetrics { get; set; } = new List<TeamResultMetric>();

    public virtual ICollection<Tournament> Tournaments { get; set; } = new List<Tournament>();
}
