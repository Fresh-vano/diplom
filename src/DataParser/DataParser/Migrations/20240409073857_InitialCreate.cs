using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataParser.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Tier = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Prize = table.Column<int>(type: "integer", nullable: false),
                    EventType = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Discipline = table.Column<int>(type: "integer", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournaments_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    TournamentId = table.Column<int>(type: "integer", nullable: false),
                    StageType = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stages_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Acronym = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    IconData = table.Column<string>(type: "text", nullable: true),
                    IconUrl = table.Column<string>(type: "text", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "text", nullable: true),
                    YoutubeUrl = table.Column<string>(type: "text", nullable: true),
                    StageId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    Team1Id = table.Column<int>(type: "integer", nullable: false),
                    Team2Id = table.Column<int>(type: "integer", nullable: false),
                    WinnerTeamId = table.Column<int>(type: "integer", nullable: true),
                    LoserTeamId = table.Column<int>(type: "integer", nullable: true),
                    Team1Score = table.Column<int>(type: "integer", nullable: false),
                    Team2Score = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    BOType = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ParsedStatus = table.Column<int>(type: "integer", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true),
                    DemoUrl = table.Column<string>(type: "text", nullable: true),
                    Discipline = table.Column<int>(type: "integer", nullable: false),
                    TournamentID = table.Column<int>(type: "integer", nullable: false),
                    StageId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Teams_LoserTeamId",
                        column: x => x.LoserTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Teams_Team1Id",
                        column: x => x.Team1Id,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_Team2Id",
                        column: x => x.Team2Id,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_WinnerTeamId",
                        column: x => x.WinnerTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Tournaments_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nickname = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    ImageData = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamNames_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamTournament",
                columns: table => new
                {
                    TeamsId = table.Column<int>(type: "integer", nullable: false),
                    TournamentsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamTournament", x => new { x.TeamsId, x.TournamentsId });
                    table.ForeignKey(
                        name: "FK_TeamTournament_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamTournament_Tournaments_TournamentsId",
                        column: x => x.TournamentsId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MatchID = table.Column<int>(type: "integer", nullable: false),
                    BeginAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    MapName = table.Column<int>(type: "integer", nullable: false),
                    WinnerScore = table.Column<int>(type: "integer", nullable: false),
                    LoserScore = table.Column<int>(type: "integer", nullable: false),
                    WinnerId = table.Column<int>(type: "integer", nullable: false),
                    LoserId = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    RoundCount = table.Column<int>(type: "integer", nullable: false),
                    Discipline = table.Column<int>(type: "integer", nullable: false),
                    DemoName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maps_Matches_MatchID",
                        column: x => x.MatchID,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maps_Teams_LoserId",
                        column: x => x.LoserId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maps_Teams_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerMetrics",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerID = table.Column<int>(type: "integer", nullable: false),
                    MapID = table.Column<int>(type: "integer", nullable: false),
                    Kills = table.Column<int>(type: "integer", nullable: false),
                    Assists = table.Column<int>(type: "integer", nullable: false),
                    Deaths = table.Column<int>(type: "integer", nullable: false),
                    KD = table.Column<double>(type: "double precision", nullable: false),
                    HS = table.Column<int>(type: "integer", nullable: false),
                    HSPercent = table.Column<double>(type: "double precision", nullable: false),
                    Rounds = table.Column<int>(type: "integer", nullable: false),
                    RWS = table.Column<double>(type: "double precision", nullable: false),
                    KAST = table.Column<double>(type: "double precision", nullable: false),
                    Rating = table.Column<double>(type: "double precision", nullable: false),
                    Rating2 = table.Column<double>(type: "double precision", nullable: false),
                    ATDs = table.Column<double>(type: "double precision", nullable: false),
                    FiveKill = table.Column<int>(type: "integer", nullable: false),
                    FourKill = table.Column<int>(type: "integer", nullable: false),
                    ThreeKill = table.Column<int>(type: "integer", nullable: false),
                    TwoKill = table.Column<int>(type: "integer", nullable: false),
                    OneKill = table.Column<int>(type: "integer", nullable: false),
                    TradeKill = table.Column<int>(type: "integer", nullable: false),
                    TradeDeath = table.Column<int>(type: "integer", nullable: false),
                    TeamKill = table.Column<int>(type: "integer", nullable: false),
                    JumpKill = table.Column<int>(type: "integer", nullable: false),
                    CrouchKill = table.Column<int>(type: "integer", nullable: false),
                    BombPlanted = table.Column<int>(type: "integer", nullable: false),
                    BombDefused = table.Column<int>(type: "integer", nullable: false),
                    BombExploded = table.Column<int>(type: "integer", nullable: false),
                    MVP = table.Column<int>(type: "integer", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    Clutch = table.Column<int>(type: "integer", nullable: false),
                    ClutchWon = table.Column<int>(type: "integer", nullable: false),
                    ClutchLost = table.Column<int>(type: "integer", nullable: false),
                    ClutchWonPercent = table.Column<double>(type: "double precision", nullable: false),
                    OneVOne = table.Column<int>(type: "integer", nullable: false),
                    OneVOneWon = table.Column<int>(type: "integer", nullable: false),
                    OneVOneLost = table.Column<int>(type: "integer", nullable: false),
                    OneVOneWonPercent = table.Column<double>(type: "double precision", nullable: false),
                    OneVTwo = table.Column<int>(type: "integer", nullable: false),
                    OneVTwoWon = table.Column<int>(type: "integer", nullable: false),
                    OneVTwoLost = table.Column<int>(type: "integer", nullable: false),
                    OneVTwoWonPercent = table.Column<double>(type: "double precision", nullable: false),
                    OneVThree = table.Column<int>(type: "integer", nullable: false),
                    OneVThreeWon = table.Column<int>(type: "integer", nullable: false),
                    OneVThreeLost = table.Column<int>(type: "integer", nullable: false),
                    OneVThreeWonPercent = table.Column<double>(type: "double precision", nullable: false),
                    OneVFour = table.Column<int>(type: "integer", nullable: false),
                    OneVFourWon = table.Column<int>(type: "integer", nullable: false),
                    OneVFourLost = table.Column<int>(type: "integer", nullable: false),
                    OneVFourWonPercent = table.Column<double>(type: "double precision", nullable: false),
                    OneVFive = table.Column<int>(type: "integer", nullable: false),
                    OneVFiveWon = table.Column<int>(type: "integer", nullable: false),
                    OneVFiveLost = table.Column<int>(type: "integer", nullable: false),
                    OneVFiveWonPercent = table.Column<double>(type: "double precision", nullable: false),
                    EntryKill = table.Column<int>(type: "integer", nullable: false),
                    EntryKillWin = table.Column<int>(type: "integer", nullable: false),
                    EntryKillLost = table.Column<int>(type: "integer", nullable: false),
                    EntryKillWinPercent = table.Column<double>(type: "double precision", nullable: false),
                    EntryHoldKill = table.Column<int>(type: "integer", nullable: false),
                    EntryHoldKillWin = table.Column<int>(type: "integer", nullable: false),
                    EntryHoldKillLost = table.Column<int>(type: "integer", nullable: false),
                    EntryHoldKillWinPercent = table.Column<double>(type: "double precision", nullable: false),
                    KPR = table.Column<double>(type: "double precision", nullable: false),
                    APR = table.Column<double>(type: "double precision", nullable: false),
                    DPR = table.Column<double>(type: "double precision", nullable: false),
                    ADR = table.Column<double>(type: "double precision", nullable: false),
                    TDH = table.Column<int>(type: "integer", nullable: false),
                    TDA = table.Column<int>(type: "integer", nullable: false),
                    Flashbang = table.Column<int>(type: "integer", nullable: false),
                    Smoke = table.Column<int>(type: "integer", nullable: false),
                    HE = table.Column<int>(type: "integer", nullable: false),
                    Decoy = table.Column<int>(type: "integer", nullable: false),
                    Molotov = table.Column<int>(type: "integer", nullable: false),
                    Incendiary = table.Column<int>(type: "integer", nullable: false),
                    RankMax = table.Column<int>(type: "integer", nullable: false),
                    VAC = table.Column<bool>(type: "boolean", nullable: false),
                    OW = table.Column<bool>(type: "boolean", nullable: false),
                    SurvivedRounds = table.Column<int>(type: "integer", nullable: false),
                    Hits = table.Column<int>(type: "integer", nullable: false),
                    Shots = table.Column<int>(type: "integer", nullable: false),
                    KillThroughSmoke = table.Column<int>(type: "integer", nullable: false),
                    AverageTimeToKill = table.Column<double>(type: "double precision", nullable: false),
                    Rage = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMetrics", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlayerMetrics_Maps_MapID",
                        column: x => x.MapID,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerMetrics_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerResultMetric",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerID = table.Column<int>(type: "integer", nullable: false),
                    MapID = table.Column<int>(type: "integer", nullable: false),
                    KD = table.Column<double>(type: "double precision", nullable: false),
                    RoundWin = table.Column<double>(type: "double precision", nullable: false),
                    EcoWin = table.Column<double>(type: "double precision", nullable: false),
                    EntryPerc = table.Column<double>(type: "double precision", nullable: false),
                    FlashKills = table.Column<double>(type: "double precision", nullable: false),
                    KAST = table.Column<double>(type: "double precision", nullable: false),
                    ADR = table.Column<double>(type: "double precision", nullable: false),
                    Rating2 = table.Column<double>(type: "double precision", nullable: false),
                    Survived = table.Column<double>(type: "double precision", nullable: false),
                    Rating3 = table.Column<double>(type: "double precision", nullable: false),
                    K54321 = table.Column<double>(type: "double precision", nullable: false),
                    Win4vs5Perc = table.Column<double>(type: "double precision", nullable: false),
                    Win5vs4Perc = table.Column<double>(type: "double precision", nullable: false),
                    BuhScore = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerResultMetric", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlayerResultMetric_Maps_MapID",
                        column: x => x.MapID,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerResultMetric_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamMetrics",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MapID = table.Column<int>(type: "integer", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    KillCount = table.Column<int>(type: "integer", nullable: false),
                    DeathCount = table.Column<int>(type: "integer", nullable: false),
                    AssistCount = table.Column<int>(type: "integer", nullable: false),
                    RoundCount = table.Column<int>(type: "integer", nullable: false),
                    RoundWonCount = table.Column<int>(type: "integer", nullable: false),
                    RoundLostCount = table.Column<int>(type: "integer", nullable: false),
                    RoundWonAsCtCount = table.Column<int>(type: "integer", nullable: false),
                    RoundLostAsCtCount = table.Column<int>(type: "integer", nullable: false),
                    RoundWonAsTerroCount = table.Column<int>(type: "integer", nullable: false),
                    RoundLostAsTerroCount = table.Column<int>(type: "integer", nullable: false),
                    PistolRoundWonCount = table.Column<int>(type: "integer", nullable: false),
                    PistolRoundCount = table.Column<int>(type: "integer", nullable: false),
                    EcoRoundWonCount = table.Column<int>(type: "integer", nullable: false),
                    EcoRoundCount = table.Column<int>(type: "integer", nullable: false),
                    SemiEcoRoundWonCount = table.Column<int>(type: "integer", nullable: false),
                    SemiEcoRoundCount = table.Column<int>(type: "integer", nullable: false),
                    ForceBuyRoundWonCount = table.Column<int>(type: "integer", nullable: false),
                    ForceBuyRoundCount = table.Column<int>(type: "integer", nullable: false),
                    BombPlantedCount = table.Column<int>(type: "integer", nullable: false),
                    BombDefusedCount = table.Column<int>(type: "integer", nullable: false),
                    BombExplodedCount = table.Column<int>(type: "integer", nullable: false),
                    BombPlantedOnACount = table.Column<int>(type: "integer", nullable: false),
                    BombPlantedOnBCount = table.Column<int>(type: "integer", nullable: false),
                    FiveKillCount = table.Column<int>(type: "integer", nullable: false),
                    FourKillCount = table.Column<int>(type: "integer", nullable: false),
                    ThreeKillCount = table.Column<int>(type: "integer", nullable: false),
                    TwoKillCount = table.Column<int>(type: "integer", nullable: false),
                    OneKillCount = table.Column<int>(type: "integer", nullable: false),
                    TradeKillCount = table.Column<int>(type: "integer", nullable: false),
                    TradeDeathCount = table.Column<int>(type: "integer", nullable: false),
                    JumpKillCount = table.Column<int>(type: "integer", nullable: false),
                    CrouchKillCount = table.Column<int>(type: "integer", nullable: false),
                    FlashbangCount = table.Column<int>(type: "integer", nullable: false),
                    HeGrenadeCount = table.Column<int>(type: "integer", nullable: false),
                    SmokeCount = table.Column<int>(type: "integer", nullable: false),
                    MolotovCount = table.Column<int>(type: "integer", nullable: false),
                    IncendiaryCount = table.Column<int>(type: "integer", nullable: false),
                    DecoyCount = table.Column<int>(type: "integer", nullable: false),
                    WinFourVSFive = table.Column<int>(type: "integer", nullable: false),
                    WinFourVSFivePercent = table.Column<double>(type: "double precision", nullable: false),
                    AllFourVSFiveRounds = table.Column<int>(type: "integer", nullable: false),
                    WinFiveVSFour = table.Column<int>(type: "integer", nullable: false),
                    WinFiveVSFourPercent = table.Column<double>(type: "double precision", nullable: false),
                    AllFiveVSFourRounds = table.Column<int>(type: "integer", nullable: false),
                    FlashKills = table.Column<int>(type: "integer", nullable: false),
                    FlashTeamKills = table.Column<int>(type: "integer", nullable: false),
                    UtilityBuy = table.Column<int>(type: "integer", nullable: false),
                    UtilityUse = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMetrics", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TeamMetrics_Maps_MapID",
                        column: x => x.MapID,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMetrics_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoundPlayerMetric",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerID = table.Column<int>(type: "integer", nullable: false),
                    RoundID = table.Column<int>(type: "integer", nullable: false),
                    Kills = table.Column<int>(type: "integer", nullable: false),
                    Assists = table.Column<int>(type: "integer", nullable: false),
                    Deaths = table.Column<int>(type: "integer", nullable: false),
                    HS = table.Column<int>(type: "integer", nullable: false),
                    FiveKill = table.Column<bool>(type: "boolean", nullable: false),
                    FourKill = table.Column<bool>(type: "boolean", nullable: false),
                    ThreeKill = table.Column<bool>(type: "boolean", nullable: false),
                    TwoKill = table.Column<bool>(type: "boolean", nullable: false),
                    OneKill = table.Column<bool>(type: "boolean", nullable: false),
                    TradeKill = table.Column<int>(type: "integer", nullable: false),
                    TradeDeath = table.Column<int>(type: "integer", nullable: false),
                    TeamKill = table.Column<int>(type: "integer", nullable: false),
                    JumpKill = table.Column<int>(type: "integer", nullable: false),
                    CrouchKill = table.Column<int>(type: "integer", nullable: false),
                    BombPlanted = table.Column<bool>(type: "boolean", nullable: false),
                    BombDefused = table.Column<bool>(type: "boolean", nullable: false),
                    MVP = table.Column<bool>(type: "boolean", nullable: false),
                    ClutchWon = table.Column<bool>(type: "boolean", nullable: false),
                    EntryKill = table.Column<bool>(type: "boolean", nullable: false),
                    Flashbang = table.Column<int>(type: "integer", nullable: false),
                    Smoke = table.Column<int>(type: "integer", nullable: false),
                    HE = table.Column<int>(type: "integer", nullable: false),
                    Decoy = table.Column<int>(type: "integer", nullable: false),
                    Molotov = table.Column<int>(type: "integer", nullable: false),
                    Incendiary = table.Column<int>(type: "integer", nullable: false),
                    Hits = table.Column<int>(type: "integer", nullable: false),
                    Shots = table.Column<int>(type: "integer", nullable: false),
                    KillThroughSmoke = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundPlayerMetric", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoundPlayerMetric_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EndReason = table.Column<int>(type: "integer", nullable: false),
                    MapId = table.Column<int>(type: "integer", nullable: false),
                    RoundNumber = table.Column<int>(type: "integer", nullable: false),
                    LoserTeamScore = table.Column<int>(type: "integer", nullable: false),
                    LoserTeamSide = table.Column<int>(type: "integer", nullable: false),
                    LoserTeamId = table.Column<int>(type: "integer", nullable: false),
                    WinnerTeamScore = table.Column<int>(type: "integer", nullable: false),
                    WinnerTeamSide = table.Column<int>(type: "integer", nullable: false),
                    WinnerTeamId = table.Column<int>(type: "integer", nullable: false),
                    Team1MetricId = table.Column<int>(type: "integer", nullable: false),
                    Team2MetricId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rounds_Maps_MapId",
                        column: x => x.MapId,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rounds_Teams_LoserTeamId",
                        column: x => x.LoserTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rounds_Teams_WinnerTeamId",
                        column: x => x.WinnerTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoundTeamMetric",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    RoundId = table.Column<int>(type: "integer", nullable: false),
                    RoundId1 = table.Column<int>(type: "integer", nullable: false),
                    MapId = table.Column<int>(type: "integer", nullable: false),
                    StartMoney = table.Column<int>(type: "integer", nullable: false),
                    EquipmentValue = table.Column<int>(type: "integer", nullable: false),
                    MoneySpend = table.Column<int>(type: "integer", nullable: false),
                    EconomyType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundTeamMetric", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoundTeamMetric_Maps_MapId",
                        column: x => x.MapId,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoundTeamMetric_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoundTeamMetric_Rounds_RoundId1",
                        column: x => x.RoundId1,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoundTeamMetric_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maps_LoserId",
                table: "Maps",
                column: "LoserId");

            migrationBuilder.CreateIndex(
                name: "IX_Maps_MatchID",
                table: "Maps",
                column: "MatchID");

            migrationBuilder.CreateIndex(
                name: "IX_Maps_WinnerId",
                table: "Maps",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_LoserTeamId",
                table: "Matches",
                column: "LoserTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_StageId",
                table: "Matches",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Team1Id",
                table: "Matches",
                column: "Team1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Team2Id",
                table: "Matches",
                column: "Team2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TournamentID",
                table: "Matches",
                column: "TournamentID");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_WinnerTeamId",
                table: "Matches",
                column: "WinnerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMetrics_MapID",
                table: "PlayerMetrics",
                column: "MapID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMetrics_PlayerID",
                table: "PlayerMetrics",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerResultMetric_MapID",
                table: "PlayerResultMetric",
                column: "MapID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerResultMetric_PlayerID",
                table: "PlayerResultMetric",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CountryId",
                table: "Players",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundPlayerMetric_PlayerID",
                table: "RoundPlayerMetric",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_RoundPlayerMetric_RoundID",
                table: "RoundPlayerMetric",
                column: "RoundID");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_LoserTeamId",
                table: "Rounds",
                column: "LoserTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_MapId",
                table: "Rounds",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_Team1MetricId",
                table: "Rounds",
                column: "Team1MetricId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_WinnerTeamId",
                table: "Rounds",
                column: "WinnerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundTeamMetric_MapId",
                table: "RoundTeamMetric",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundTeamMetric_RoundId",
                table: "RoundTeamMetric",
                column: "RoundId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoundTeamMetric_RoundId1",
                table: "RoundTeamMetric",
                column: "RoundId1");

            migrationBuilder.CreateIndex(
                name: "IX_RoundTeamMetric_TeamId",
                table: "RoundTeamMetric",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_TournamentId",
                table: "Stages",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMetrics_MapID",
                table: "TeamMetrics",
                column: "MapID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMetrics_TeamId",
                table: "TeamMetrics",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamNames_TeamId",
                table: "TeamNames",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CountryId",
                table: "Teams",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StageId",
                table: "Teams",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamTournament_TournamentsId",
                table: "TeamTournament",
                column: "TournamentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_CountryId",
                table: "Tournaments",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoundPlayerMetric_Rounds_RoundID",
                table: "RoundPlayerMetric",
                column: "RoundID",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_RoundTeamMetric_Team1MetricId",
                table: "Rounds",
                column: "Team1MetricId",
                principalTable: "RoundTeamMetric",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maps_Matches_MatchID",
                table: "Maps");

            migrationBuilder.DropForeignKey(
                name: "FK_Maps_Teams_LoserId",
                table: "Maps");

            migrationBuilder.DropForeignKey(
                name: "FK_Maps_Teams_WinnerId",
                table: "Maps");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Teams_LoserTeamId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Teams_WinnerTeamId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_RoundTeamMetric_Teams_TeamId",
                table: "RoundTeamMetric");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Maps_MapId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_RoundTeamMetric_Maps_MapId",
                table: "RoundTeamMetric");

            migrationBuilder.DropForeignKey(
                name: "FK_RoundTeamMetric_Rounds_RoundId",
                table: "RoundTeamMetric");

            migrationBuilder.DropForeignKey(
                name: "FK_RoundTeamMetric_Rounds_RoundId1",
                table: "RoundTeamMetric");

            migrationBuilder.DropTable(
                name: "PlayerMetrics");

            migrationBuilder.DropTable(
                name: "PlayerResultMetric");

            migrationBuilder.DropTable(
                name: "RoundPlayerMetric");

            migrationBuilder.DropTable(
                name: "TeamMetrics");

            migrationBuilder.DropTable(
                name: "TeamNames");

            migrationBuilder.DropTable(
                name: "TeamTournament");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "RoundTeamMetric");
        }
    }
}
