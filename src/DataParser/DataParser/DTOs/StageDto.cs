using Newtonsoft.Json;

namespace DataParser.DTOs
{
	public class StageDto
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("format_type")]
		public string FormatType { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("teams")]
		public List<TeamDto> Teams { get; set; }
	}
}
