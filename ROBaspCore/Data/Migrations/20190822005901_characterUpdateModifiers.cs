using Microsoft.EntityFrameworkCore.Migrations;

namespace ROBaspCore.Data.Migrations
{
    public partial class characterUpdateModifiers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgileModifier",
                table: "CharacterSheetModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AttractiveModifier",
                table: "CharacterSheetModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CharismaticModifier",
                table: "CharacterSheetModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadStrongModifier",
                table: "CharacterSheetModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KnowledgeableModifier",
                table: "CharacterSheetModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrecisionModifier",
                table: "CharacterSheetModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RobustModifier",
                table: "CharacterSheetModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StrongModifier",
                table: "CharacterSheetModel",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgileModifier",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "AttractiveModifier",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "CharismaticModifier",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "HeadStrongModifier",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "KnowledgeableModifier",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "PrecisionModifier",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "RobustModifier",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "StrongModifier",
                table: "CharacterSheetModel");
        }
    }
}
