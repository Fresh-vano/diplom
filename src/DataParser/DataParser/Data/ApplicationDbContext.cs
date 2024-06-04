using DataParser.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataParser.Data
{
	public class ApplicationDbContext : DbContext, IApplicationDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Map> Maps { get; set; }

		public DbSet<Match> Matches { get; set; }
		
		public DbSet<Player> Players { get; set; }

		public DbSet<PlayerMetric> PlayerMetrics { get; set; }

		public DbSet<Round> Rounds { get; set; }

		public DbSet<Stage> Stages { get; set; }

		public DbSet<Team> Teams { get; set; }

		public DbSet<TeamResultMetric> TeamMetrics { get; set; }

		public DbSet<TeamName> TeamNames { get; set; }

		public DbSet<Tournament> Tournaments { get; set; }

		public DbSet<Country> Countries { get; set; }

		public DbSet<PlayerStats> PlayerStats { get; set; }

		DbSet<Map> IApplicationDbContext.Maps => Maps;
		DbSet<Match> IApplicationDbContext.Matches => Matches;
		DbSet<Player> IApplicationDbContext.Players => Players;

		DbSet<PlayerMetric> IApplicationDbContext.PlayerMetrics => PlayerMetrics;
		DbSet<Round> IApplicationDbContext.Rounds => Rounds;
		DbSet<Stage> IApplicationDbContext.Stages => Stages;
		DbSet<Team> IApplicationDbContext.Teams => Teams;
		DbSet<TeamResultMetric> IApplicationDbContext.TeamMetrics => TeamMetrics;
		DbSet<TeamName> IApplicationDbContext.TeamNames => TeamNames;
		DbSet<Tournament> IApplicationDbContext.Tournaments => Tournaments;
		DbSet<Country> IApplicationDbContext.Countries => Countries;
		DbSet<PlayerStats> IApplicationDbContext.PlayerStats => PlayerStats;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Round>()
				.HasOne(r => r.Team1Metric)
				.WithOne()
				.HasForeignKey<RoundTeamMetric>(rtm => rtm.RoundId);

			modelBuilder.Entity<Round>()
				.HasOne(r => r.Team2Metric)
				.WithOne()
				.HasForeignKey<RoundTeamMetric>(rtm => rtm.RoundId);
		}

		public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			return await base.SaveChangesAsync(cancellationToken);
		}

		public override int SaveChanges()
		{
			return base.SaveChanges();
		}
	}
}
