using Microsoft.EntityFrameworkCore.Migrations;

namespace ROBaspCore.Data.Migrations
{
    public partial class addingArmorControllers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArmorRestorationModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmorStyle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DamageRatingRestoration = table.Column<int>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    RepairTimeHours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorRestorationModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArmorRestrictionModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FeatValuePenalty = table.Column<int>(nullable: false),
                    CastingPenalty = table.Column<int>(nullable: false),
                    EvasionPenalty = table.Column<int>(nullable: false),
                    MovementPenalty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorRestrictionModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArmorModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DefenseRating = table.Column<int>(nullable: false),
                    ArmorRestrictionId = table.Column<int>(nullable: false),
                    ArmorRestorationId = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Cost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArmorModel_ArmorRestorationModel_ArmorRestorationId",
                        column: x => x.ArmorRestorationId,
                        principalTable: "ArmorRestorationModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmorModel_ArmorRestrictionModel_ArmorRestrictionId",
                        column: x => x.ArmorRestrictionId,
                        principalTable: "ArmorRestrictionModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSheet_Armor_Link",
                columns: table => new
                {
                    CharacterSheetId = table.Column<int>(nullable: false),
                    ArmorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheet_Armor_Link", x => new { x.CharacterSheetId, x.ArmorId });
                    table.ForeignKey(
                        name: "FK_CharacterSheet_Armor_Link_ArmorModel_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "ArmorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSheet_Armor_Link_CharacterSheetModel_CharacterSheetId",
                        column: x => x.CharacterSheetId,
                        principalTable: "CharacterSheetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmorModel_ArmorRestorationId",
                table: "ArmorModel",
                column: "ArmorRestorationId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmorModel_ArmorRestrictionId",
                table: "ArmorModel",
                column: "ArmorRestrictionId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheet_Armor_Link_ArmorId",
                table: "CharacterSheet_Armor_Link",
                column: "ArmorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterSheet_Armor_Link");

            migrationBuilder.DropTable(
                name: "ArmorModel");

            migrationBuilder.DropTable(
                name: "ArmorRestorationModel");

            migrationBuilder.DropTable(
                name: "ArmorRestrictionModel");
        }
    }
}
