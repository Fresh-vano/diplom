using System;
using System.Collections.Generic;
using DataSearch.Models;
using Microsoft.EntityFrameworkCore;

namespace DataSearch.Data;

public partial class Cs2Context : DbContext
{
    public Cs2Context()
    {
    }

    public Cs2Context(DbContextOptions<Cs2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Map> Maps { get; set; }

    public virtual DbSet<Match> Matches { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerMetric> PlayerMetrics { get; set; }

    public virtual DbSet<PlayerResultMetric> PlayerResultMetrics { get; set; }

    public virtual DbSet<PlayerStat> PlayerStats { get; set; }

    public virtual DbSet<Round> Rounds { get; set; }

    public virtual DbSet<RoundPlayerMetric> RoundPlayerMetrics { get; set; }

    public virtual DbSet<RoundTeamMetric> RoundTeamMetrics { get; set; }

    public virtual DbSet<Stage> Stages { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamName> TeamNames { get; set; }

    public virtual DbSet<TeamResultMetric> TeamResultMetrics { get; set; }

    public virtual DbSet<Tournament> Tournaments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.Code).HasDefaultValueSql("''::text");
        });

        modelBuilder.Entity<Map>(entity =>
        {
            entity.ToTable("Map");

            entity.HasIndex(e => e.LoserId, "IX_Map_LoserId");

            entity.HasIndex(e => e.MatchId, "IX_Map_MatchID");

            entity.HasIndex(e => e.WinnerId, "IX_Map_WinnerId");

            entity.Property(e => e.MatchId).HasColumnName("MatchID");

            entity.HasOne(d => d.Loser).WithMany(p => p.MapLosers).HasForeignKey(d => d.LoserId);

            entity.HasOne(d => d.Match).WithMany(p => p.Maps).HasForeignKey(d => d.MatchId);

            entity.HasOne(d => d.Winner).WithMany(p => p.MapWinners).HasForeignKey(d => d.WinnerId);
        });

        modelBuilder.Entity<Match>(entity =>
        {
            entity.ToTable("Match");

            entity.HasIndex(e => e.LoserTeamId, "IX_Match_LoserTeamId");

            entity.HasIndex(e => e.StageId, "IX_Match_StageId");

            entity.HasIndex(e => e.Team1Id, "IX_Match_Team1Id");

            entity.HasIndex(e => e.Team2Id, "IX_Match_Team2Id");

            entity.HasIndex(e => e.TournamentId, "IX_Match_TournamentID");

            entity.HasIndex(e => e.WinnerTeamId, "IX_Match_WinnerTeamId");

            entity.Property(e => e.Botype).HasColumnName("BOType");
            entity.Property(e => e.TournamentId).HasColumnName("TournamentID");

            entity.HasOne(d => d.LoserTeam).WithMany(p => p.MatchLoserTeams).HasForeignKey(d => d.LoserTeamId);

            entity.HasOne(d => d.Stage).WithMany(p => p.Matches).HasForeignKey(d => d.StageId);

            entity.HasOne(d => d.Team1).WithMany(p => p.MatchTeam1s).HasForeignKey(d => d.Team1Id);

            entity.HasOne(d => d.Team2).WithMany(p => p.MatchTeam2s).HasForeignKey(d => d.Team2Id);

            entity.HasOne(d => d.Tournament).WithMany(p => p.Matches).HasForeignKey(d => d.TournamentId);

            entity.HasOne(d => d.WinnerTeam).WithMany(p => p.MatchWinnerTeams).HasForeignKey(d => d.WinnerTeamId);
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.ToTable("Player");

            entity.HasIndex(e => e.CountryId, "IX_Player_CountryId");

            entity.HasIndex(e => e.TeamId, "IX_Player_TeamId");

            entity.HasOne(d => d.Country).WithMany(p => p.Players).HasForeignKey(d => d.CountryId);

            entity.HasOne(d => d.Team).WithMany(p => p.Players).HasForeignKey(d => d.TeamId);
        });

        modelBuilder.Entity<PlayerMetric>(entity =>
        {
            entity.ToTable("PlayerMetric");

            entity.HasIndex(e => e.MapId, "IX_PlayerMetric_MapID");

            entity.HasIndex(e => e.PlayerId, "IX_PlayerMetric_PlayerID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adr).HasColumnName("ADR");
            entity.Property(e => e.Apr).HasColumnName("APR");
            entity.Property(e => e.Atds).HasColumnName("ATDs");
            entity.Property(e => e.Dpr).HasColumnName("DPR");
            entity.Property(e => e.He).HasColumnName("HE");
            entity.Property(e => e.Hs).HasColumnName("HS");
            entity.Property(e => e.Hspercent).HasColumnName("HSPercent");
            entity.Property(e => e.Kast).HasColumnName("KAST");
            entity.Property(e => e.Kd).HasColumnName("KD");
            entity.Property(e => e.Kpr).HasColumnName("KPR");
            entity.Property(e => e.MapId).HasColumnName("MapID");
            entity.Property(e => e.Mvp).HasColumnName("MVP");
            entity.Property(e => e.OneVfive).HasColumnName("OneVFive");
            entity.Property(e => e.OneVfiveLost).HasColumnName("OneVFiveLost");
            entity.Property(e => e.OneVfiveWon).HasColumnName("OneVFiveWon");
            entity.Property(e => e.OneVfiveWonPercent).HasColumnName("OneVFiveWonPercent");
            entity.Property(e => e.OneVfour).HasColumnName("OneVFour");
            entity.Property(e => e.OneVfourLost).HasColumnName("OneVFourLost");
            entity.Property(e => e.OneVfourWon).HasColumnName("OneVFourWon");
            entity.Property(e => e.OneVfourWonPercent).HasColumnName("OneVFourWonPercent");
            entity.Property(e => e.OneVone).HasColumnName("OneVOne");
            entity.Property(e => e.OneVoneLost).HasColumnName("OneVOneLost");
            entity.Property(e => e.OneVoneWon).HasColumnName("OneVOneWon");
            entity.Property(e => e.OneVoneWonPercent).HasColumnName("OneVOneWonPercent");
            entity.Property(e => e.OneVthree).HasColumnName("OneVThree");
            entity.Property(e => e.OneVthreeLost).HasColumnName("OneVThreeLost");
            entity.Property(e => e.OneVthreeWon).HasColumnName("OneVThreeWon");
            entity.Property(e => e.OneVthreeWonPercent).HasColumnName("OneVThreeWonPercent");
            entity.Property(e => e.OneVtwo).HasColumnName("OneVTwo");
            entity.Property(e => e.OneVtwoLost).HasColumnName("OneVTwoLost");
            entity.Property(e => e.OneVtwoWon).HasColumnName("OneVTwoWon");
            entity.Property(e => e.OneVtwoWonPercent).HasColumnName("OneVTwoWonPercent");
            entity.Property(e => e.Ow).HasColumnName("OW");
            entity.Property(e => e.PlayerId).HasColumnName("PlayerID");
            entity.Property(e => e.Rws).HasColumnName("RWS");
            entity.Property(e => e.Tda).HasColumnName("TDA");
            entity.Property(e => e.Tdh).HasColumnName("TDH");
            entity.Property(e => e.Vac).HasColumnName("VAC");

            entity.HasOne(d => d.Map).WithMany(p => p.PlayerMetrics).HasForeignKey(d => d.MapId);

            entity.HasOne(d => d.Player).WithMany(p => p.PlayerMetrics).HasForeignKey(d => d.PlayerId);
        });

        modelBuilder.Entity<PlayerResultMetric>(entity =>
        {
            entity.ToTable("PlayerResultMetric");

            entity.HasIndex(e => e.MapId, "IX_PlayerResultMetric_MapID");

            entity.HasIndex(e => e.PlayerId, "IX_PlayerResultMetric_PlayerID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adr).HasColumnName("ADR");
            entity.Property(e => e.Kast).HasColumnName("KAST");
            entity.Property(e => e.Kd).HasColumnName("KD");
            entity.Property(e => e.MapId).HasColumnName("MapID");
            entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

            entity.HasOne(d => d.Map).WithMany(p => p.PlayerResultMetrics).HasForeignKey(d => d.MapId);

            entity.HasOne(d => d.Player).WithMany(p => p.PlayerResultMetrics).HasForeignKey(d => d.PlayerId);
        });

        modelBuilder.Entity<PlayerStat>(entity =>
        {
            entity.HasIndex(e => e.MapId, "IX_PlayerStats_MapId");

            entity.HasIndex(e => e.PlayerId, "IX_PlayerStats_PlayerId");

            entity.HasIndex(e => e.TeamId, "IX_PlayerStats_TeamId");

            entity.HasOne(d => d.Map).WithMany(p => p.PlayerStats).HasForeignKey(d => d.MapId);

            entity.HasOne(d => d.Player).WithMany(p => p.PlayerStats).HasForeignKey(d => d.PlayerId);

            entity.HasOne(d => d.Team).WithMany(p => p.PlayerStats).HasForeignKey(d => d.TeamId);
        });

        modelBuilder.Entity<Round>(entity =>
        {
            entity.ToTable("Round");

            entity.HasIndex(e => e.LoserTeamId, "IX_Round_LoserTeamId");

            entity.HasIndex(e => e.MapId, "IX_Round_MapId");

            entity.HasIndex(e => e.Team1MetricId, "IX_Round_Team1MetricId");

            entity.HasIndex(e => e.WinnerTeamId, "IX_Round_WinnerTeamId");

            entity.HasOne(d => d.LoserTeam).WithMany(p => p.RoundLoserTeams).HasForeignKey(d => d.LoserTeamId);

            entity.HasOne(d => d.Map).WithMany(p => p.Rounds).HasForeignKey(d => d.MapId);

            entity.HasOne(d => d.Team1Metric).WithMany(p => p.Rounds).HasForeignKey(d => d.Team1MetricId);

            entity.HasOne(d => d.WinnerTeam).WithMany(p => p.RoundWinnerTeams).HasForeignKey(d => d.WinnerTeamId);
        });

        modelBuilder.Entity<RoundPlayerMetric>(entity =>
        {
            entity.ToTable("RoundPlayerMetric");

            entity.HasIndex(e => e.PlayerId, "IX_RoundPlayerMetric_PlayerID");

            entity.HasIndex(e => e.RoundId, "IX_RoundPlayerMetric_RoundID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.He).HasColumnName("HE");
            entity.Property(e => e.Hs).HasColumnName("HS");
            entity.Property(e => e.Mvp).HasColumnName("MVP");
            entity.Property(e => e.PlayerId).HasColumnName("PlayerID");
            entity.Property(e => e.RoundId).HasColumnName("RoundID");

            entity.HasOne(d => d.Player).WithMany(p => p.RoundPlayerMetrics).HasForeignKey(d => d.PlayerId);

            entity.HasOne(d => d.Round).WithMany(p => p.RoundPlayerMetrics).HasForeignKey(d => d.RoundId);
        });

        modelBuilder.Entity<RoundTeamMetric>(entity =>
        {
            entity.ToTable("RoundTeamMetric");

            entity.HasIndex(e => e.MapId, "IX_RoundTeamMetric_MapId");

            entity.HasIndex(e => e.RoundId, "IX_RoundTeamMetric_RoundId").IsUnique();

            entity.HasIndex(e => e.RoundId1, "IX_RoundTeamMetric_RoundId1");

            entity.HasIndex(e => e.TeamId, "IX_RoundTeamMetric_TeamId");

            entity.HasOne(d => d.Map).WithMany(p => p.RoundTeamMetrics).HasForeignKey(d => d.MapId);

            entity.HasOne(d => d.Round).WithOne(p => p.RoundTeamMetricRound).HasForeignKey<RoundTeamMetric>(d => d.RoundId);

            entity.HasOne(d => d.RoundId1Navigation).WithMany(p => p.RoundTeamMetricRoundId1Navigations).HasForeignKey(d => d.RoundId1);

            entity.HasOne(d => d.Team).WithMany(p => p.RoundTeamMetrics).HasForeignKey(d => d.TeamId);
        });

        modelBuilder.Entity<Stage>(entity =>
        {
            entity.ToTable("Stage");

            entity.HasIndex(e => e.TournamentId, "IX_Stage_TournamentId");

            entity.HasOne(d => d.Tournament).WithMany(p => p.Stages).HasForeignKey(d => d.TournamentId);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.ToTable("Team");

            entity.HasIndex(e => e.CountryId, "IX_Team_CountryId");

            entity.HasIndex(e => e.StageId, "IX_Team_StageId");

            entity.HasOne(d => d.Country).WithMany(p => p.Teams).HasForeignKey(d => d.CountryId);

            entity.HasOne(d => d.Stage).WithMany(p => p.Teams).HasForeignKey(d => d.StageId);

            entity.HasMany(d => d.Tournaments).WithMany(p => p.Teams)
                .UsingEntity<Dictionary<string, object>>(
                    "TeamTournament",
                    r => r.HasOne<Tournament>().WithMany().HasForeignKey("TournamentsId"),
                    l => l.HasOne<Team>().WithMany().HasForeignKey("TeamsId"),
                    j =>
                    {
                        j.HasKey("TeamsId", "TournamentsId");
                        j.ToTable("TeamTournament");
                        j.HasIndex(new[] { "TournamentsId" }, "IX_TeamTournament_TournamentsId");
                    });
        });

        modelBuilder.Entity<TeamName>(entity =>
        {
            entity.ToTable("TeamName");

            entity.HasIndex(e => e.TeamId, "IX_TeamName_TeamId");

            entity.HasOne(d => d.Team).WithMany(p => p.TeamNames).HasForeignKey(d => d.TeamId);
        });

        modelBuilder.Entity<TeamResultMetric>(entity =>
        {
            entity.ToTable("TeamResultMetric");

            entity.HasIndex(e => e.MapId, "IX_TeamResultMetric_MapID");

            entity.HasIndex(e => e.TeamId, "IX_TeamResultMetric_TeamId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AllFiveVsfourRounds).HasColumnName("AllFiveVSFourRounds");
            entity.Property(e => e.AllFourVsfiveRounds).HasColumnName("AllFourVSFiveRounds");
            entity.Property(e => e.BombPlantedOnAcount).HasColumnName("BombPlantedOnACount");
            entity.Property(e => e.BombPlantedOnBcount).HasColumnName("BombPlantedOnBCount");
            entity.Property(e => e.MapId).HasColumnName("MapID");
            entity.Property(e => e.WinFiveVsfour).HasColumnName("WinFiveVSFour");
            entity.Property(e => e.WinFiveVsfourPercent).HasColumnName("WinFiveVSFourPercent");
            entity.Property(e => e.WinFourVsfive).HasColumnName("WinFourVSFive");
            entity.Property(e => e.WinFourVsfivePercent).HasColumnName("WinFourVSFivePercent");

            entity.HasOne(d => d.Map).WithMany(p => p.TeamResultMetrics).HasForeignKey(d => d.MapId);

            entity.HasOne(d => d.Team).WithMany(p => p.TeamResultMetrics).HasForeignKey(d => d.TeamId);
        });

        modelBuilder.Entity<Tournament>(entity =>
        {
            entity.ToTable("Tournament");

            entity.HasIndex(e => e.CountryId, "IX_Tournament_CountryId");

            entity.HasOne(d => d.Country).WithMany(p => p.Tournaments).HasForeignKey(d => d.CountryId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
