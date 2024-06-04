using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataParser.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayerStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MapId = table.Column<int>(type: "integer", nullable: false),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    Win = table.Column<int>(type: "integer", nullable: false),
                    Kills = table.Column<int>(type: "integer", nullable: false),
                    Assists = table.Column<int>(type: "integer", nullable: false),
                    Death = table.Column<int>(type: "integer", nullable: false),
                    Adr = table.Column<double>(type: "double precision", nullable: false),
                    AdditionalValue = table.Column<int>(type: "integer", nullable: false),
                    Clutches = table.Column<int>(type: "integer", nullable: false),
                    CumulativeRoundDamages = table.Column<string>(type: "text", nullable: false),
                    Damage = table.Column<int>(type: "integer", nullable: false),
                    FirstKills = table.Column<int>(type: "integer", nullable: false),
                    FirstDeath = table.Column<int>(type: "integer", nullable: false),
                    GotDamage = table.Column<int>(type: "integer", nullable: false),
                    Headshots = table.Column<int>(type: "integer", nullable: false),
                    Hits = table.Column<int>(type: "integer", nullable: false),
                    Kast = table.Column<double>(type: "double precision", nullable: false),
                    MoneySpent = table.Column<int>(type: "integer", nullable: false),
                    MoneySave = table.Column<int>(type: "integer", nullable: false),
                    Multikills = table.Column<string>(type: "text", nullable: false),
                    PistolsValue = table.Column<int>(type: "integer", nullable: false),
                    PlayerRating = table.Column<double>(type: "double precision", nullable: false),
                    Shots = table.Column<int>(type: "integer", nullable: false),
                    TotalEquipmentValue = table.Column<int>(type: "integer", nullable: false),
                    WeaponsValue = table.Column<int>(type: "integer", nullable: false),
                    TradeDeath = table.Column<int>(type: "integer", nullable: false),
                    TradeKills = table.Column<int>(type: "integer", nullable: false),
                    UtilityValue = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerStats_Map_MapId",
                        column: x => x.MapId,
                        principalTable: "Map",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerStats_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerStats_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStats_MapId",
                table: "PlayerStats",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStats_PlayerId",
                table: "PlayerStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStats_TeamId",
                table: "PlayerStats",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerStats");
        }
    }
}
