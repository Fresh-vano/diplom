using DataParser.Models;
using Microsoft.EntityFrameworkCore;

namespace DataParser.Data
{
	public interface IApplicationDbContext
	{
		DbSet<Map> Maps { get; }
		DbSet<Match> Matches { get; }
		DbSet<Player> Players { get; }
		DbSet<PlayerMetric> PlayerMetrics { get; }
		DbSet<Round> Rounds { get; }
		DbSet<Stage> Stages { get; }
		DbSet<Team> Teams { get; }
		DbSet<TeamResultMetric> TeamMetrics { get; }
		DbSet<TeamName> TeamNames { get; }
		DbSet<Tournament> Tournaments { get; }
		DbSet<Country> Countries { get; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
		int SaveChanges();
	}
}
