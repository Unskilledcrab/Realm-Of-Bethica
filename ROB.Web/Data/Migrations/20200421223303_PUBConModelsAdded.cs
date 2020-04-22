using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ROB.Web.Data.Migrations
{
    public partial class PUBConModelsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PUBConGameModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GameType = table.Column<string>(nullable: true),
                    MinimumPlayers = table.Column<int>(nullable: false),
                    MaximumPlayers = table.Column<int>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false),
                    EventDuration = table.Column<double>(nullable: false),
                    MessageToPlayers = table.Column<string>(nullable: true),
                    GameMaster = table.Column<string>(nullable: true),
                    GameMasterDiscordName = table.Column<string>(nullable: true),
                    DiscordChannel = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PUBConGameModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PUBConGameModel_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_PUBConGame_Link",
                columns: table => new
                {
                    PUBConGameId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_PUBConGame_Link", x => new { x.PUBConGameId, x.UserId });
                    table.ForeignKey(
                        name: "FK_User_PUBConGame_Link_PUBConGameModel_PUBConGameId",
                        column: x => x.PUBConGameId,
                        principalTable: "PUBConGameModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_PUBConGame_Link_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PUBConGameModel_CreatorId",
                table: "PUBConGameModel",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PUBConGame_Link_UserId",
                table: "User_PUBConGame_Link",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_PUBConGame_Link");

            migrationBuilder.DropTable(
                name: "PUBConGameModel");
        }
    }
}
