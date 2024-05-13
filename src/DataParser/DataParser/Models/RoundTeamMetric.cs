using DataParser.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataParser.Models
{
	public class RoundTeamMetric
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey("Team")]
		public int TeamId { get; set; }

		public Team? Team { get; set; }

		[ForeignKey("Round")]
		public int RoundId {  get; set; }
		
		public Round Round { get; set; }

		[ForeignKey("Map")]
		public int MapId { get; set; }

		public Map? Map { get; set; }

		public int StartMoney { get; set; }

		public int EquipmentValue { get; set; }

		public int MoneySpend { get; set; }

		public EconomyTypeEnum EconomyType { get; set;}
	}
}
