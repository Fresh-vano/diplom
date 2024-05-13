using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DataParser.DTOs
{
	public class PlayerDto
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("slug")]
		public string Slug { get; set; }

		[JsonProperty("nickname")]
		public string Nickname { get; set; }

		[JsonProperty("first_name")]
		public string? FirstName { get; set; }

		[JsonProperty("last_name")]
		public string? LastName { get; set; }

		[JsonProperty("image_url")]
		public string? ImageUrl { get; set; }

		[JsonProperty("team_id")]
		public int? TeamId { get; set; }

		[JsonProperty("image_data")]
		public string? ImageData { get; set; }

		[JsonProperty("country")]
		public CountryDto Country { get; set; }
	}
}
