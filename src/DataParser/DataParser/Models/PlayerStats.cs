using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataParser.Models
{
	public class PlayerStats
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey("Map")]
		public int MapId { get; set; }
		public Map Map { get; set; }

		[ForeignKey("Player")]
		public int PlayerId { get; set; }
		public Player Player { get; set; }

		[ForeignKey("Team")]
		public int TeamId { get; set; }
		public Team Team { get; set; }

		public int Win { get; set; }
		public int Kills { get; set; }
		public int Assists { get; set; }
		public int Death { get; set; }
		public double Adr { get; set; }
		public int AdditionalValue { get; set; }
		public int Clutches { get; set; }
		public string CumulativeRoundDamages { get; set; }
		public int Damage { get; set; }
		public int FirstKills { get; set; }
		public int FirstDeath { get; set; }
		public int GotDamage { get; set; }
		public int Headshots { get; set; }
		public int Hits { get; set; }
		public double Kast { get; set; }
		public int MoneySpent { get; set; }
		public int MoneySave { get; set; }
		public string Multikills { get; set; }
		public int PistolsValue { get; set; }
		public double PlayerRating { get; set; }
		public int Shots { get; set; }
		public int TotalEquipmentValue { get; set; }
		public int WeaponsValue { get; set; }
		public int TradeDeath { get; set; }
		public int TradeKills { get; set; }
		public int UtilityValue { get; set; }
	}
}
