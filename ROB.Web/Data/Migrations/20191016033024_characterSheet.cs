using Microsoft.EntityFrameworkCore.Migrations;

namespace ROB.Web.Data.Migrations
{
    public partial class characterSheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "CharacterSheetModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Alignment",
                table: "CharacterSheetModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Background",
                table: "CharacterSheetModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Backstory",
                table: "CharacterSheetModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EyeColor",
                table: "CharacterSheetModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Faith",
                table: "CharacterSheetModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "CharacterSheetModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HairColor",
                table: "CharacterSheetModel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HeightInches",
                table: "CharacterSheetModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PrivateNotes",
                table: "CharacterSheetModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicNotes",
                table: "CharacterSheetModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkinColor",
                table: "CharacterSheetModel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "CharacterSheetModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CharacterSheet_Shield_Link",
                columns: table => new
                {
                    CharacterSheetId = table.Column<int>(nullable: false),
                    ShieldId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheet_Shield_Link", x => new { x.CharacterSheetId, x.ShieldId });
                    table.ForeignKey(
                        name: "FK_CharacterSheet_Shield_Link_CharacterSheetModel_CharacterSheetId",
                        column: x => x.CharacterSheetId,
                        principalTable: "CharacterSheetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSheet_Shield_Link_ShieldModel_ShieldId",
                        column: x => x.ShieldId,
                        principalTable: "ShieldModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheet_Shield_Link_ShieldId",
                table: "CharacterSheet_Shield_Link",
                column: "ShieldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterSheet_Shield_Link");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "Alignment",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "Background",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "Backstory",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "EyeColor",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "Faith",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "HairColor",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "HeightInches",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "PrivateNotes",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "PublicNotes",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "SkinColor",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "CharacterSheetModel");
        }
    }
}
