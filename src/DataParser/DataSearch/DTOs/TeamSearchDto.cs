namespace DataSearch.DTOs
{
	public class TeamSearchDto
	{
		public int Id { get; set; }

		public string Slug { get; set; } = string.Empty;

		public string Name { get; set; } = string.Empty;

		public string? IconUrl { get; set; }
	}
}
