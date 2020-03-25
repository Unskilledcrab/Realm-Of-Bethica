using Microsoft.EntityFrameworkCore.Migrations;

namespace ROBaspCore.Data.Migrations
{
    public partial class fixingShieldModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefenseRating",
                table: "ShieldModel");

            migrationBuilder.AddColumn<int>(
                name: "DefensePoints",
                table: "ShieldModel",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefensePoints",
                table: "ShieldModel");

            migrationBuilder.AddColumn<int>(
                name: "DefenseRating",
                table: "ShieldModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
