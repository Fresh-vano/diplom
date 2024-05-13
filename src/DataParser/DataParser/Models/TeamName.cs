using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataParser.Models
{
	public class TeamName
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = string.Empty;

		[ForeignKey("Team")]
		public int TeamId { get; set; }

		public Team? Team { get; set; }
	}
}
