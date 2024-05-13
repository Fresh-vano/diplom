namespace DataParser.Services
{
	public interface IMatchUpdateService
	{
		Task UpdateMatchMinFinishedAsync();

		Task UpdateMatchAsync();
	}
}
