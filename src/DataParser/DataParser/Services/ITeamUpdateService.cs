namespace DataParser.Services
{
	public interface ITeamUpdateService
	{
		Task UpdateTeamsAsync();

		Task UpdateTeamNameAsync();
	}
}
