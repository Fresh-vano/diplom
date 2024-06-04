using System;
using System.Collections.Generic;

namespace DataSearch.Models;

public partial class Stage
{
    public int Id { get; set; }

    public int Status { get; set; }

    public string Title { get; set; } = null!;

    public int TournamentId { get; set; }

    public int StageType { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Match> Matches { get; set; } = new List<Match>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

    public virtual Tournament Tournament { get; set; } = null!;
}
