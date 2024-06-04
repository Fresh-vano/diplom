using System;
using System.Collections.Generic;

namespace DataSearch.Models;

public partial class Match
{
    public int Id { get; set; }

    public string Slug { get; set; } = null!;

    public int Team1Id { get; set; }

    public int Team2Id { get; set; }

    public int? WinnerTeamId { get; set; }

    public int? LoserTeamId { get; set; }

    public int Team1Score { get; set; }

    public int Team2Score { get; set; }

    public int Status { get; set; }

    public int Botype { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int ParsedStatus { get; set; }

    public string? Url { get; set; }

    public string? DemoUrl { get; set; }

    public int Discipline { get; set; }

    public int TournamentId { get; set; }

    public int? StageId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Team? LoserTeam { get; set; }

    public virtual ICollection<Map> Maps { get; set; } = new List<Map>();

    public virtual Stage? Stage { get; set; }

    public virtual Team Team1 { get; set; } = null!;

    public virtual Team Team2 { get; set; } = null!;

    public virtual Tournament Tournament { get; set; } = null!;

    public virtual Team? WinnerTeam { get; set; }
}
