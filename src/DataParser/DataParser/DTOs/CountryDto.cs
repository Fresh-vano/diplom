using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DataParser.DTOs
{
	public class CountryDto
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
