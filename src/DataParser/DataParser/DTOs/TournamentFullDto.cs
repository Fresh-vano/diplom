using Newtonsoft.Json;

namespace DataParser.DTOs
{
	public class TournamentFullDto
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("event_type")]
		public string EventType { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("discipline")]
		public string Discipline { get; set; }

		[JsonProperty("image_url")]
		public string ImageUrl { get; set; }

		[JsonProperty("country_id")]
		public int Country { get; set; }

		[JsonProperty("stages")]
		public List<StageDto> Stages { get; set; }
	}
}
