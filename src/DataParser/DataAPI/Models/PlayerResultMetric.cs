using System;
using System.Collections.Generic;

namespace DataAPI.Models;

public partial class PlayerResultMetric
{
    public int Id { get; set; }

    public int PlayerId { get; set; }

    public int MapId { get; set; }

    public double Kd { get; set; }

    public double RoundWin { get; set; }

    public double EcoWin { get; set; }

    public double EntryPerc { get; set; }

    public double FlashKills { get; set; }

    public double Kast { get; set; }

    public double Adr { get; set; }

    public double Rating2 { get; set; }

    public double Survived { get; set; }

    public double Rating3 { get; set; }

    public double K54321 { get; set; }

    public double Win4vs5Perc { get; set; }

    public double Win5vs4Perc { get; set; }

    public double BuhScore { get; set; }

    public virtual Map Map { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;
}
