using Microsoft.EntityFrameworkCore.Migrations;

namespace ROBaspCore.Data.Migrations
{
    public partial class addingCharacterSheetWeaponsLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterSheet_Weapon_Link",
                columns: table => new
                {
                    CharacterSheetId = table.Column<int>(nullable: false),
                    WeaponId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheet_Weapon_Link", x => new { x.CharacterSheetId, x.WeaponId });
                    table.ForeignKey(
                        name: "FK_CharacterSheet_Weapon_Link_CharacterSheetModel_CharacterSheetId",
                        column: x => x.CharacterSheetId,
                        principalTable: "CharacterSheetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSheet_Weapon_Link_WeaponModel_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "WeaponModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheet_Weapon_Link_WeaponId",
                table: "CharacterSheet_Weapon_Link",
                column: "WeaponId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterSheet_Weapon_Link");
        }
    }
}
