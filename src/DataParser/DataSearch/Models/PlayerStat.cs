using System;
using System.Collections.Generic;

namespace DataSearch.Models;

public partial class PlayerStat
{
    public int Id { get; set; }

    public int MapId { get; set; }

    public int PlayerId { get; set; }

    public int TeamId { get; set; }

    public int Win { get; set; }

    public int Kills { get; set; }

    public int Assists { get; set; }

    public int Death { get; set; }

    public double Adr { get; set; }

    public int AdditionalValue { get; set; }

    public int Clutches { get; set; }

    public string CumulativeRoundDamages { get; set; } = null!;

    public int Damage { get; set; }

    public int FirstKills { get; set; }

    public int FirstDeath { get; set; }

    public int GotDamage { get; set; }

    public int Headshots { get; set; }

    public int Hits { get; set; }

    public double Kast { get; set; }

    public int MoneySpent { get; set; }

    public int MoneySave { get; set; }

    public string Multikills { get; set; } = null!;

    public int PistolsValue { get; set; }

    public double PlayerRating { get; set; }

    public int Shots { get; set; }

    public int TotalEquipmentValue { get; set; }

    public int WeaponsValue { get; set; }

    public int TradeDeath { get; set; }

    public int TradeKills { get; set; }

    public int UtilityValue { get; set; }

    public virtual Map Map { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;

    public virtual Team Team { get; set; } = null!;
}
