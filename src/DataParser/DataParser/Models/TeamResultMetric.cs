using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataParser.Models
{
	public class TeamResultMetric
	{
		[Key]
		public int ID { get; set; }

		[Required]
		[ForeignKey("Map")]
		public int MapID { get; set; }

		public Map? Map { get; set; }

		[Required]
		[ForeignKey("Team")]
		public int TeamId { get; set; }

		public Team? Team { get; set; }

		public int KillCount { get; set; }

		public int DeathCount { get; set; }

		public int AssistCount { get; set; }

		public int RoundCount { get; set; }

		public int RoundWonCount { get; set; }

		public int RoundLostCount { get; set; }

		public int RoundWonAsCtCount { get; set; }

		public int RoundLostAsCtCount { get; set; }

		public int RoundWonAsTerroCount { get; set; }

		public int RoundLostAsTerroCount { get; set; }

		public int PistolRoundWonCount { get; set; }

		public int PistolRoundCount { get; set; }

		public int EcoRoundWonCount { get; set; }

		public int EcoRoundCount { get; set; }

		public int SemiEcoRoundWonCount { get; set; }

		public int SemiEcoRoundCount { get; set; }

		public int ForceBuyRoundWonCount { get; set; }

		public int ForceBuyRoundCount { get; set; }

		public int BombPlantedCount { get; set; }

		public int BombDefusedCount { get; set; }

		public int BombExplodedCount { get; set; }

		public int BombPlantedOnACount { get; set; }

		public int BombPlantedOnBCount { get; set; }

		public int FiveKillCount { get; set; }

		public int FourKillCount { get; set; }

		public int ThreeKillCount { get; set; }

		public int TwoKillCount { get; set; }

		public int OneKillCount { get; set; }

		public int TradeKillCount { get; set; }

		public int TradeDeathCount { get; set; }

		public int JumpKillCount { get; set; }

		public int CrouchKillCount { get; set; }

		public int FlashbangCount { get; set; }

		public int HeGrenadeCount { get; set; }

		public int SmokeCount { get; set; }

		public int MolotovCount { get; set; }

		public int IncendiaryCount { get; set; }

		public int DecoyCount { get; set; }

		public int WinFourVSFive { get; set; }

		public double WinFourVSFivePercent { get; set; }

		public int AllFourVSFiveRounds { get; set; }

		public int WinFiveVSFour { get; set; }

		public double WinFiveVSFourPercent { get; set; }

		public int AllFiveVSFourRounds { get; set; }

		public int FlashKills { get; set; }

		public int FlashTeamKills { get; set; }

		public int UtilityBuy { get; set; }

		public int UtilityUse { get; set; }
	}
}
