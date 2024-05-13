namespace DataParser.Services
{
	public interface ITournamentUpdateService
	{
		Task UpdateTournamentMinFinishedAsync();
		Task UpdateTournamentMinUpcomingAsync();
		Task UpdateTournamentAsync();
	}
}
