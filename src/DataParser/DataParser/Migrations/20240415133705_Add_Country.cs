using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataParser.Migrations
{
    /// <inheritdoc />
    public partial class Add_Country : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_Matches_Stages_StageId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_LoserTeamId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_Team1Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_Team2Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_WinnerTeamId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Tournaments_TournamentID",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMetrics_Maps_MapID",
                table: "PlayerMetrics");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMetrics_Players_PlayerID",
                table: "PlayerMetrics");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerResultMetric_Maps_MapID",
                table: "PlayerResultMetric");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerResultMetric_Players_PlayerID",
                table: "PlayerResultMetric");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Country_CountryId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_RoundPlayerMetric_Players_PlayerID",
                table: "RoundPlayerMetric");

            migrationBuilder.DropForeignKey(
                name: "FK_RoundPlayerMetric_Rounds_RoundID",
                table: "RoundPlayerMetric");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Maps_MapId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_RoundTeamMetric_Team1MetricId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Teams_LoserTeamId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Teams_WinnerTeamId",
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

            migrationBuilder.DropForeignKey(
                name: "FK_RoundTeamMetric_Teams_TeamId",
                table: "RoundTeamMetric");

            migrationBuilder.DropForeignKey(
                name: "FK_Stages_Tournaments_TournamentId",
                table: "Stages");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMetrics_Maps_MapID",
                table: "TeamMetrics");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMetrics_Teams_TeamId",
                table: "TeamMetrics");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamNames_Teams_TeamId",
                table: "TeamNames");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Country_CountryId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Stages_StageId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamTournament_Teams_TeamsId",
                table: "TeamTournament");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamTournament_Tournaments_TournamentsId",
                table: "TeamTournament");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Country_CountryId",
                table: "Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tournaments",
                table: "Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamNames",
                table: "TeamNames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMetrics",
                table: "TeamMetrics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stages",
                table: "Stages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rounds",
                table: "Rounds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerMetrics",
                table: "PlayerMetrics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matches",
                table: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Maps",
                table: "Maps");

            migrationBuilder.DropColumn(
                name: "IconData",
                table: "Teams");

            migrationBuilder.RenameTable(
                name: "Tournaments",
                newName: "Tournament");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Team");

            migrationBuilder.RenameTable(
                name: "TeamNames",
                newName: "TeamName");

            migrationBuilder.RenameTable(
                name: "TeamMetrics",
                newName: "TeamResultMetric");

            migrationBuilder.RenameTable(
                name: "Stages",
                newName: "Stage");

            migrationBuilder.RenameTable(
                name: "Rounds",
                newName: "Round");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Player");

            migrationBuilder.RenameTable(
                name: "PlayerMetrics",
                newName: "PlayerMetric");

            migrationBuilder.RenameTable(
                name: "Matches",
                newName: "Match");

            migrationBuilder.RenameTable(
                name: "Maps",
                newName: "Map");

            migrationBuilder.RenameIndex(
                name: "IX_Tournaments_CountryId",
                table: "Tournament",
                newName: "IX_Tournament_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_StageId",
                table: "Team",
                newName: "IX_Team_StageId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_CountryId",
                table: "Team",
                newName: "IX_Team_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamNames_TeamId",
                table: "TeamName",
                newName: "IX_TeamName_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMetrics_TeamId",
                table: "TeamResultMetric",
                newName: "IX_TeamResultMetric_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMetrics_MapID",
                table: "TeamResultMetric",
                newName: "IX_TeamResultMetric_MapID");

            migrationBuilder.RenameIndex(
                name: "IX_Stages_TournamentId",
                table: "Stage",
                newName: "IX_Stage_TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_Rounds_WinnerTeamId",
                table: "Round",
                newName: "IX_Round_WinnerTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Rounds_Team1MetricId",
                table: "Round",
                newName: "IX_Round_Team1MetricId");

            migrationBuilder.RenameIndex(
                name: "IX_Rounds_MapId",
                table: "Round",
                newName: "IX_Round_MapId");

            migrationBuilder.RenameIndex(
                name: "IX_Rounds_LoserTeamId",
                table: "Round",
                newName: "IX_Round_LoserTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_TeamId",
                table: "Player",
                newName: "IX_Player_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_CountryId",
                table: "Player",
                newName: "IX_Player_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerMetrics_PlayerID",
                table: "PlayerMetric",
                newName: "IX_PlayerMetric_PlayerID");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerMetrics_MapID",
                table: "PlayerMetric",
                newName: "IX_PlayerMetric_MapID");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_WinnerTeamId",
                table: "Match",
                newName: "IX_Match_WinnerTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_TournamentID",
                table: "Match",
                newName: "IX_Match_TournamentID");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_Team2Id",
                table: "Match",
                newName: "IX_Match_Team2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_Team1Id",
                table: "Match",
                newName: "IX_Match_Team1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_StageId",
                table: "Match",
                newName: "IX_Match_StageId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_LoserTeamId",
                table: "Match",
                newName: "IX_Match_LoserTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Maps_WinnerId",
                table: "Map",
                newName: "IX_Map_WinnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Maps_MatchID",
                table: "Map",
                newName: "IX_Map_MatchID");

            migrationBuilder.RenameIndex(
                name: "IX_Maps_LoserId",
                table: "Map",
                newName: "IX_Map_LoserId");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Country",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tournament",
                table: "Tournament",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamName",
                table: "TeamName",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamResultMetric",
                table: "TeamResultMetric",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stage",
                table: "Stage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Round",
                table: "Round",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Player",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerMetric",
                table: "PlayerMetric",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Match",
                table: "Match",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Map",
                table: "Map",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Map_Match_MatchID",
                table: "Map",
                column: "MatchID",
                principalTable: "Match",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Map_Team_LoserId",
                table: "Map",
                column: "LoserId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Map_Team_WinnerId",
                table: "Map",
                column: "WinnerId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Stage_StageId",
                table: "Match",
                column: "StageId",
                principalTable: "Stage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_LoserTeamId",
                table: "Match",
                column: "LoserTeamId",
                principalTable: "Team",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_Team1Id",
                table: "Match",
                column: "Team1Id",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_Team2Id",
                table: "Match",
                column: "Team2Id",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_WinnerTeamId",
                table: "Match",
                column: "WinnerTeamId",
                principalTable: "Team",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Tournament_TournamentID",
                table: "Match",
                column: "TournamentID",
                principalTable: "Tournament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Country_CountryId",
                table: "Player",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMetric_Map_MapID",
                table: "PlayerMetric",
                column: "MapID",
                principalTable: "Map",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMetric_Player_PlayerID",
                table: "PlayerMetric",
                column: "PlayerID",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerResultMetric_Map_MapID",
                table: "PlayerResultMetric",
                column: "MapID",
                principalTable: "Map",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerResultMetric_Player_PlayerID",
                table: "PlayerResultMetric",
                column: "PlayerID",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Round_Map_MapId",
                table: "Round",
                column: "MapId",
                principalTable: "Map",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Round_RoundTeamMetric_Team1MetricId",
                table: "Round",
                column: "Team1MetricId",
                principalTable: "RoundTeamMetric",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Round_Team_LoserTeamId",
                table: "Round",
                column: "LoserTeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Round_Team_WinnerTeamId",
                table: "Round",
                column: "WinnerTeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoundPlayerMetric_Player_PlayerID",
                table: "RoundPlayerMetric",
                column: "PlayerID",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoundPlayerMetric_Round_RoundID",
                table: "RoundPlayerMetric",
                column: "RoundID",
                principalTable: "Round",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoundTeamMetric_Map_MapId",
                table: "RoundTeamMetric",
                column: "MapId",
                principalTable: "Map",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoundTeamMetric_Round_RoundId",
                table: "RoundTeamMetric",
                column: "RoundId",
                principalTable: "Round",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoundTeamMetric_Round_RoundId1",
                table: "RoundTeamMetric",
                column: "RoundId1",
                principalTable: "Round",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoundTeamMetric_Team_TeamId",
                table: "RoundTeamMetric",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stage_Tournament_TournamentId",
                table: "Stage",
                column: "TournamentId",
                principalTable: "Tournament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Country_CountryId",
                table: "Team",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Stage_StageId",
                table: "Team",
                column: "StageId",
                principalTable: "Stage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamName_Team_TeamId",
                table: "TeamName",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamResultMetric_Map_MapID",
                table: "TeamResultMetric",
                column: "MapID",
                principalTable: "Map",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamResultMetric_Team_TeamId",
                table: "TeamResultMetric",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamTournament_Team_TeamsId",
                table: "TeamTournament",
                column: "TeamsId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamTournament_Tournament_TournamentsId",
                table: "TeamTournament",
                column: "TournamentsId",
                principalTable: "Tournament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_Country_CountryId",
                table: "Tournament",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Map_Match_MatchID",
                table: "Map");

            migrationBuilder.DropForeignKey(
                name: "FK_Map_Team_LoserId",
                table: "Map");

            migrationBuilder.DropForeignKey(
                name: "FK_Map_Team_WinnerId",
                table: "Map");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Stage_StageId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_LoserTeamId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_Team1Id",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_Team2Id",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_WinnerTeamId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Tournament_TournamentID",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Country_CountryId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMetric_Map_MapID",
                table: "PlayerMetric");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMetric_Player_PlayerID",
                table: "PlayerMetric");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerResultMetric_Map_MapID",
                table: "PlayerResultMetric");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerResultMetric_Player_PlayerID",
                table: "PlayerResultMetric");

            migrationBuilder.DropForeignKey(
                name: "FK_Round_Map_MapId",
                table: "Round");

            migrationBuilder.DropForeignKey(
                name: "FK_Round_RoundTeamMetric_Team1MetricId",
                table: "Round");

            migrationBuilder.DropForeignKey(
                name: "FK_Round_Team_LoserTeamId",
                table: "Round");

            migrationBuilder.DropForeignKey(
                name: "FK_Round_Team_WinnerTeamId",
                table: "Round");

            migrationBuilder.DropForeignKey(
                name: "FK_RoundPlayerMetric_Player_PlayerID",
                table: "RoundPlayerMetric");

            migrationBuilder.DropForeignKey(
                name: "FK_RoundPlayerMetric_Round_RoundID",
                table: "RoundPlayerMetric");

            migrationBuilder.DropForeignKey(
                name: "FK_RoundTeamMetric_Map_MapId",
                table: "RoundTeamMetric");

            migrationBuilder.DropForeignKey(
                name: "FK_RoundTeamMetric_Round_RoundId",
                table: "RoundTeamMetric");

            migrationBuilder.DropForeignKey(
                name: "FK_RoundTeamMetric_Round_RoundId1",
                table: "RoundTeamMetric");

            migrationBuilder.DropForeignKey(
                name: "FK_RoundTeamMetric_Team_TeamId",
                table: "RoundTeamMetric");

            migrationBuilder.DropForeignKey(
                name: "FK_Stage_Tournament_TournamentId",
                table: "Stage");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Country_CountryId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Stage_StageId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamName_Team_TeamId",
                table: "TeamName");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamResultMetric_Map_MapID",
                table: "TeamResultMetric");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamResultMetric_Team_TeamId",
                table: "TeamResultMetric");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamTournament_Team_TeamsId",
                table: "TeamTournament");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamTournament_Tournament_TournamentsId",
                table: "TeamTournament");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_Country_CountryId",
                table: "Tournament");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tournament",
                table: "Tournament");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamResultMetric",
                table: "TeamResultMetric");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamName",
                table: "TeamName");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stage",
                table: "Stage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Round",
                table: "Round");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerMetric",
                table: "PlayerMetric");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Match",
                table: "Match");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Map",
                table: "Map");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Country");

            migrationBuilder.RenameTable(
                name: "Tournament",
                newName: "Tournaments");

            migrationBuilder.RenameTable(
                name: "TeamResultMetric",
                newName: "TeamMetrics");

            migrationBuilder.RenameTable(
                name: "TeamName",
                newName: "TeamNames");

            migrationBuilder.RenameTable(
                name: "Team",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "Stage",
                newName: "Stages");

            migrationBuilder.RenameTable(
                name: "Round",
                newName: "Rounds");

            migrationBuilder.RenameTable(
                name: "PlayerMetric",
                newName: "PlayerMetrics");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "Players");

            migrationBuilder.RenameTable(
                name: "Match",
                newName: "Matches");

            migrationBuilder.RenameTable(
                name: "Map",
                newName: "Maps");

            migrationBuilder.RenameIndex(
                name: "IX_Tournament_CountryId",
                table: "Tournaments",
                newName: "IX_Tournaments_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamResultMetric_TeamId",
                table: "TeamMetrics",
                newName: "IX_TeamMetrics_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamResultMetric_MapID",
                table: "TeamMetrics",
                newName: "IX_TeamMetrics_MapID");

            migrationBuilder.RenameIndex(
                name: "IX_TeamName_TeamId",
                table: "TeamNames",
                newName: "IX_TeamNames_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Team_StageId",
                table: "Teams",
                newName: "IX_Teams_StageId");

            migrationBuilder.RenameIndex(
                name: "IX_Team_CountryId",
                table: "Teams",
                newName: "IX_Teams_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Stage_TournamentId",
                table: "Stages",
                newName: "IX_Stages_TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_Round_WinnerTeamId",
                table: "Rounds",
                newName: "IX_Rounds_WinnerTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Round_Team1MetricId",
                table: "Rounds",
                newName: "IX_Rounds_Team1MetricId");

            migrationBuilder.RenameIndex(
                name: "IX_Round_MapId",
                table: "Rounds",
                newName: "IX_Rounds_MapId");

            migrationBuilder.RenameIndex(
                name: "IX_Round_LoserTeamId",
                table: "Rounds",
                newName: "IX_Rounds_LoserTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerMetric_PlayerID",
                table: "PlayerMetrics",
                newName: "IX_PlayerMetrics_PlayerID");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerMetric_MapID",
                table: "PlayerMetrics",
                newName: "IX_PlayerMetrics_MapID");

            migrationBuilder.RenameIndex(
                name: "IX_Player_TeamId",
                table: "Players",
                newName: "IX_Players_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Player_CountryId",
                table: "Players",
                newName: "IX_Players_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Match_WinnerTeamId",
                table: "Matches",
                newName: "IX_Matches_WinnerTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Match_TournamentID",
                table: "Matches",
                newName: "IX_Matches_TournamentID");

            migrationBuilder.RenameIndex(
                name: "IX_Match_Team2Id",
                table: "Matches",
                newName: "IX_Matches_Team2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Match_Team1Id",
                table: "Matches",
                newName: "IX_Matches_Team1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Match_StageId",
                table: "Matches",
                newName: "IX_Matches_StageId");

            migrationBuilder.RenameIndex(
                name: "IX_Match_LoserTeamId",
                table: "Matches",
                newName: "IX_Matches_LoserTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Map_WinnerId",
                table: "Maps",
                newName: "IX_Maps_WinnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Map_MatchID",
                table: "Maps",
                newName: "IX_Maps_MatchID");

            migrationBuilder.RenameIndex(
                name: "IX_Map_LoserId",
                table: "Maps",
                newName: "IX_Maps_LoserId");

            migrationBuilder.AddColumn<string>(
                name: "IconData",
                table: "Teams",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tournaments",
                table: "Tournaments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMetrics",
                table: "TeamMetrics",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamNames",
                table: "TeamNames",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stages",
                table: "Stages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rounds",
                table: "Rounds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerMetrics",
                table: "PlayerMetrics",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matches",
                table: "Matches",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maps",
                table: "Maps",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_Matches_MatchID",
                table: "Maps",
                column: "MatchID",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_Teams_LoserId",
                table: "Maps",
                column: "LoserId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maps_Teams_WinnerId",
                table: "Maps",
                column: "WinnerId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Stages_StageId",
                table: "Matches",
                column: "StageId",
                principalTable: "Stages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_LoserTeamId",
                table: "Matches",
                column: "LoserTeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_Team1Id",
                table: "Matches",
                column: "Team1Id",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_Team2Id",
                table: "Matches",
                column: "Team2Id",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_WinnerTeamId",
                table: "Matches",
                column: "WinnerTeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Tournaments_TournamentID",
                table: "Matches",
                column: "TournamentID",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMetrics_Maps_MapID",
                table: "PlayerMetrics",
                column: "MapID",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMetrics_Players_PlayerID",
                table: "PlayerMetrics",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerResultMetric_Maps_MapID",
                table: "PlayerResultMetric",
                column: "MapID",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerResultMetric_Players_PlayerID",
                table: "PlayerResultMetric",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Country_CountryId",
                table: "Players",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoundPlayerMetric_Players_PlayerID",
                table: "RoundPlayerMetric",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoundPlayerMetric_Rounds_RoundID",
                table: "RoundPlayerMetric",
                column: "RoundID",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Maps_MapId",
                table: "Rounds",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_RoundTeamMetric_Team1MetricId",
                table: "Rounds",
                column: "Team1MetricId",
                principalTable: "RoundTeamMetric",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Teams_LoserTeamId",
                table: "Rounds",
                column: "LoserTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Teams_WinnerTeamId",
                table: "Rounds",
                column: "WinnerTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoundTeamMetric_Maps_MapId",
                table: "RoundTeamMetric",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoundTeamMetric_Rounds_RoundId",
                table: "RoundTeamMetric",
                column: "RoundId",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoundTeamMetric_Rounds_RoundId1",
                table: "RoundTeamMetric",
                column: "RoundId1",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoundTeamMetric_Teams_TeamId",
                table: "RoundTeamMetric",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stages_Tournaments_TournamentId",
                table: "Stages",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMetrics_Maps_MapID",
                table: "TeamMetrics",
                column: "MapID",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMetrics_Teams_TeamId",
                table: "TeamMetrics",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamNames_Teams_TeamId",
                table: "TeamNames",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Country_CountryId",
                table: "Teams",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Stages_StageId",
                table: "Teams",
                column: "StageId",
                principalTable: "Stages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamTournament_Teams_TeamsId",
                table: "TeamTournament",
                column: "TeamsId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamTournament_Tournaments_TournamentsId",
                table: "TeamTournament",
                column: "TournamentsId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Country_CountryId",
                table: "Tournaments",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");
        }
    }
}
