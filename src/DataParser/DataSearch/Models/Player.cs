using System;
using System.Collections.Generic;

namespace DataSearch.Models;

public partial class Player
{
    public int Id { get; set; }

    public string Nickname { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Slug { get; set; } = null!;

    public string? ImageData { get; set; }

    public string? ImageUrl { get; set; }

    public int? TeamId { get; set; }

    public int? CountryId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<PlayerMetric> PlayerMetrics { get; set; } = new List<PlayerMetric>();

    public virtual ICollection<PlayerResultMetric> PlayerResultMetrics { get; set; } = new List<PlayerResultMetric>();

    public virtual ICollection<PlayerStat> PlayerStats { get; set; } = new List<PlayerStat>();

    public virtual ICollection<RoundPlayerMetric> RoundPlayerMetrics { get; set; } = new List<RoundPlayerMetric>();

    public virtual Team? Team { get; set; }
}
