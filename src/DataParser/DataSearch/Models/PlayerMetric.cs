using System;
using System.Collections.Generic;

namespace DataSearch.Models;

public partial class PlayerMetric
{
    public int Id { get; set; }

    public int PlayerId { get; set; }

    public int MapId { get; set; }

    public int Kills { get; set; }

    public int Assists { get; set; }

    public int Deaths { get; set; }

    public double Kd { get; set; }

    public int Hs { get; set; }

    public double Hspercent { get; set; }

    public int Rounds { get; set; }

    public double Rws { get; set; }

    public double Kast { get; set; }

    public double Rating { get; set; }

    public double Rating2 { get; set; }

    public double Atds { get; set; }

    public int FiveKill { get; set; }

    public int FourKill { get; set; }

    public int ThreeKill { get; set; }

    public int TwoKill { get; set; }

    public int OneKill { get; set; }

    public int TradeKill { get; set; }

    public int TradeDeath { get; set; }

    public int TeamKill { get; set; }

    public int JumpKill { get; set; }

    public int CrouchKill { get; set; }

    public int BombPlanted { get; set; }

    public int BombDefused { get; set; }

    public int BombExploded { get; set; }

    public int Mvp { get; set; }

    public int Score { get; set; }

    public int Clutch { get; set; }

    public int ClutchWon { get; set; }

    public int ClutchLost { get; set; }

    public double ClutchWonPercent { get; set; }

    public int OneVone { get; set; }

    public int OneVoneWon { get; set; }

    public int OneVoneLost { get; set; }

    public double OneVoneWonPercent { get; set; }

    public int OneVtwo { get; set; }

    public int OneVtwoWon { get; set; }

    public int OneVtwoLost { get; set; }

    public double OneVtwoWonPercent { get; set; }

    public int OneVthree { get; set; }

    public int OneVthreeWon { get; set; }

    public int OneVthreeLost { get; set; }

    public double OneVthreeWonPercent { get; set; }

    public int OneVfour { get; set; }

    public int OneVfourWon { get; set; }

    public int OneVfourLost { get; set; }

    public double OneVfourWonPercent { get; set; }

    public int OneVfive { get; set; }

    public int OneVfiveWon { get; set; }

    public int OneVfiveLost { get; set; }

    public double OneVfiveWonPercent { get; set; }

    public int EntryKill { get; set; }

    public int EntryKillWin { get; set; }

    public int EntryKillLost { get; set; }

    public double EntryKillWinPercent { get; set; }

    public int EntryHoldKill { get; set; }

    public int EntryHoldKillWin { get; set; }

    public int EntryHoldKillLost { get; set; }

    public double EntryHoldKillWinPercent { get; set; }

    public double Kpr { get; set; }

    public double Apr { get; set; }

    public double Dpr { get; set; }

    public double Adr { get; set; }

    public int Tdh { get; set; }

    public int Tda { get; set; }

    public int Flashbang { get; set; }

    public int Smoke { get; set; }

    public int He { get; set; }

    public int Decoy { get; set; }

    public int Molotov { get; set; }

    public int Incendiary { get; set; }

    public int RankMax { get; set; }

    public bool Vac { get; set; }

    public bool Ow { get; set; }

    public int SurvivedRounds { get; set; }

    public int Hits { get; set; }

    public int Shots { get; set; }

    public int KillThroughSmoke { get; set; }

    public double AverageTimeToKill { get; set; }

    public int Rage { get; set; }

    public virtual Map Map { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;
}
