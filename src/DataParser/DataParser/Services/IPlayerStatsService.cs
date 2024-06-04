using DataParser.Models;

namespace DataParser.Services
{
	public interface IPlayerStatsService
	{
		Task AddPlayerStatsAsync(Map map);
	}
}
