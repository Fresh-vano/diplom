using System;
using System.Collections.Generic;

namespace DataSearch.Models;

public partial class RoundTeamMetric
{
    public int Id { get; set; }

    public int TeamId { get; set; }

    public int RoundId { get; set; }

    public int RoundId1 { get; set; }

    public int MapId { get; set; }

    public int StartMoney { get; set; }

    public int EquipmentValue { get; set; }

    public int MoneySpend { get; set; }

    public int EconomyType { get; set; }

    public virtual Map Map { get; set; } = null!;

    public virtual Round Round { get; set; } = null!;

    public virtual Round RoundId1Navigation { get; set; } = null!;

    public virtual ICollection<Round> Rounds { get; set; } = new List<Round>();

    public virtual Team Team { get; set; } = null!;
}
