using Newtonsoft.Json;

namespace DataParser.DTOs
{
	public class TournamentMinDto
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("slug")]
		public string Slug { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("tier")]
		public string Tier { get; set; }

		[JsonProperty("start_date")]
		public DateTimeOffset StartDate { get; set; }

		[JsonProperty("end_date")]
		public DateTimeOffset EndDate { get; set; }

		[JsonProperty("prize")]
		public int Prize { get; set; }
	}

}
