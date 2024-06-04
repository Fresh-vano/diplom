namespace DataSearch.DTOs
{
	public class TournamentSearchDto
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string Slug { get; set; } = string.Empty;

		public string? ImageUrl { get; set; }

		public int Prize { get; set; }

		public DateTimeOffset StartDate { get; set; }

		public DateTimeOffset EndDate { get; set; }
	}
}
