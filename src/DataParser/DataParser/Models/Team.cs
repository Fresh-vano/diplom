using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataParser.Models
{
	public class Team : BaseModel
	{
		[Key]
		public int Id { get; set; }

		public string Slug { get; set; } = string.Empty;

		public string Name { get; set; } = string.Empty;

		public string? Acronym { get; set; }

		public List<TeamName>? AlternativeNames { get; set; }

		[ForeignKey("Country")]
		public int? CountryId { get; set; }

		public Country? Country { get; set; }

		public string? IconUrl { get; set; }

		public List<Player>? Players { get; set; }

		public string? WebsiteUrl { get; set; }

		public string? YoutubeUrl { get; set;}

		public List<Tournament>? Tournaments { get; set; }
	}
}
