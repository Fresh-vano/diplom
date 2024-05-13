
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DataParser.DTOs
{
	public class TeamDto
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("slug")]
		public string Slug { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("image_url")]
		public string IconUrl { get; set; }

		[JsonProperty("youtube_url")]
		public string YoutubeUrl { get; set; }

		[JsonProperty("website_url")]
		public string WebsiteUrl { get; set; }

		[JsonProperty("discipline_id")]
		public int DisciplineId { get; set; }

		[JsonProperty("acronym")]
		public string Acronym { get; set; }

		[JsonProperty("country")]
		public CountryDto Country { get; set; }
	}
}
