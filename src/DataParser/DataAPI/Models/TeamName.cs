using System;
using System.Collections.Generic;

namespace DataAPI.Models;

public partial class TeamName
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TeamId { get; set; }

    public virtual Team Team { get; set; } = null!;
}
