using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.DataProtection;

namespace DataParser.Models
{
	public class PlayerResultMetric
	{
		[Key]
		public int ID { get; set; }

		[ForeignKey("Player")]
		public int PlayerID { get; set; }

		public Player? Player { get; set; }

		[ForeignKey("Map")]
		public int MapID { get; set; }

		public Map? Map { get; set; }

		public double KD { get; set; }

		public double RoundWin { get; set; }

		public double EcoWin  { get; set;}

		public double EntryPerc { get; set; }

		public double FlashKills { get; set; }

		public double KAST {  get; set; }

		public double ADR { get; set; }

		public double Rating2 { get; set; }

		public double Survived { get; set; }

		public double Rating3 { get; set; }

		public double K54321 { get; set; }

		public double Win4vs5Perc { get; set; }

		public double Win5vs4Perc { get; set; }

		public double BuhScore { get; set; }

	}
}
