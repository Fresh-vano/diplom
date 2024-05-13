using System.ComponentModel.DataAnnotations;

namespace DataParser.Models
{
	public class Country
	{
		[Key]
		public int Id { get; set; }

		public string CountryName { get; set; } = string.Empty;

		public string Code { get; set; }
	}
}
