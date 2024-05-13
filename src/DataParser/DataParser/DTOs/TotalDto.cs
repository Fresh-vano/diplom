using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DataParser.DTOs
{
	public class TotalDto
	{
		[JsonProperty("count")]
		public int Count { get; set; }

		[JsonProperty("pages")]
		public int Pages { get; set; }

		[JsonProperty("offset")]
		public int Offset { get; set; }

		[JsonProperty("limit")]
		public int Limit { get; set; }
	}
}
