using System;
using System.Collections.Generic;

namespace DataSearch.Models;

public partial class Tournament
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public int Status { get; set; }

    public int Tier { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int Prize { get; set; }

    public int? EventType { get; set; }

    public string? Description { get; set; }

    public int? Discipline { get; set; }

    public int? CountryId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? ImageUrl { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Match> Matches { get; set; } = new List<Match>();

    public virtual ICollection<Stage> Stages { get; set; } = new List<Stage>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
