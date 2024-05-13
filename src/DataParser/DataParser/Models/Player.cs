using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataParser.Models
{
	public class Player : BaseModel
	{
		[Key]
		public int Id { get; set; }

		public string Nickname { get; set; } = string.Empty;

		public string? FirstName { get; set; }

		public string? LastName { get; set; }

		public string Slug { get; set; } = string.Empty;

		public string? ImageData { get; set; }

		public string? ImageUrl { get; set; }

		[ForeignKey("Team")]
		public int? TeamId { get; set; }

		public Team? Team { get; set; }

		[ForeignKey("Country")]
		public int? CountryId { get; set; }

		public Country? Country { get; set; }
	}
}
