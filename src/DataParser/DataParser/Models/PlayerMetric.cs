using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace DataParser.Models
{
	public class PlayerMetric
	{
		[Key]
		public int ID { get; set; }

		[ForeignKey("Player")]
		public int PlayerID { get; set; }

		public Player? Player { get; set; }

		[ForeignKey("Map")]
		public int MapID { get; set; }

		public Map? Map { get; set; }

		public int Kills { get; set; }
		public int Assists { get; set; }
		public int Deaths { get; set; }
		public double KD { get; set; }
		public int HS { get; set; }
		public double HSPercent { get; set; }
		public int Rounds { get; set; }
		public double RWS { get; set; }
		public double KAST { get; set; }
		public double Rating { get; set; }
		public double Rating2 { get; set; }
		public double ATDs { get; set; }
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
		public int MVP { get; set; }
		public int Score { get; set; }
		public int Clutch { get; set; }
		public int ClutchWon { get; set; }
		public int ClutchLost { get; set; }
		public double ClutchWonPercent { get; set; }
		public int OneVOne { get; set; }
		public int OneVOneWon { get; set; }
		public int OneVOneLost { get; set; }
		public double OneVOneWonPercent { get; set; }
		public int OneVTwo { get; set; }
		public int OneVTwoWon { get; set; }
		public int OneVTwoLost { get; set; }
		public double OneVTwoWonPercent { get; set; }
		public int OneVThree { get; set; }
		public int OneVThreeWon { get; set; }
		public int OneVThreeLost { get; set; }
		public double OneVThreeWonPercent { get; set; }
		public int OneVFour { get; set; }
		public int OneVFourWon { get; set; }
		public int OneVFourLost { get; set; }
		public double OneVFourWonPercent { get; set; }
		public int OneVFive { get; set; }
		public int OneVFiveWon { get; set; }
		public int OneVFiveLost { get; set; }
		public double OneVFiveWonPercent { get; set; }
		public int EntryKill { get; set; }
		public int EntryKillWin { get; set; }
		public int EntryKillLost { get; set; }
		public double EntryKillWinPercent { get; set; }
		public int EntryHoldKill { get; set; }
		public int EntryHoldKillWin { get; set; }
		public int EntryHoldKillLost { get; set; }
		public double EntryHoldKillWinPercent { get; set; }
		public double KPR { get; set; }
		public double APR { get; set; }
		public double DPR { get; set; }
		public double ADR { get; set; }
		public int TDH { get; set; }
		public int TDA { get; set; }
		public int Flashbang { get; set; }
		public int Smoke { get; set; }
		public int HE { get; set; }
		public int Decoy { get; set; }
		public int Molotov { get; set; }
		public int Incendiary { get; set; }
		public int RankMax { get; set; }
		public bool VAC { get; set; }
		public bool OW { get; set; }
		public int SurvivedRounds { get; set; }
		public int Hits { get; set; }
		public int Shots { get; set; }
		public int KillThroughSmoke { get; set; }
		public double AverageTimeToKill { get; set; }
		public int Rage { get; set; }

	}
}
