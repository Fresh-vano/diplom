using System;
using System.Collections.Generic;

namespace DataSearch.Models;

public partial class RoundPlayerMetric
{
    public int Id { get; set; }

    public int PlayerId { get; set; }

    public int RoundId { get; set; }

    public int Kills { get; set; }

    public int Assists { get; set; }

    public int Deaths { get; set; }

    public int Hs { get; set; }

    public bool FiveKill { get; set; }

    public bool FourKill { get; set; }

    public bool ThreeKill { get; set; }

    public bool TwoKill { get; set; }

    public bool OneKill { get; set; }

    public int TradeKill { get; set; }

    public int TradeDeath { get; set; }

    public int TeamKill { get; set; }

    public int JumpKill { get; set; }

    public int CrouchKill { get; set; }

    public bool BombPlanted { get; set; }

    public bool BombDefused { get; set; }

    public bool Mvp { get; set; }

    public bool ClutchWon { get; set; }

    public bool EntryKill { get; set; }

    public int Flashbang { get; set; }

    public int Smoke { get; set; }

    public int He { get; set; }

    public int Decoy { get; set; }

    public int Molotov { get; set; }

    public int Incendiary { get; set; }

    public int Hits { get; set; }

    public int Shots { get; set; }

    public int KillThroughSmoke { get; set; }

    public virtual Player Player { get; set; } = null!;

    public virtual Round Round { get; set; } = null!;
}
