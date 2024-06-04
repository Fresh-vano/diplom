using System;
using System.Collections.Generic;

namespace DataAPI.Models;

public partial class Country
{
    public int Id { get; set; }

    public string CountryName { get; set; } = null!;

    public string Code { get; set; } = null!;

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

    public virtual ICollection<Tournament> Tournaments { get; set; } = new List<Tournament>();
}
