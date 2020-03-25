using Microsoft.EntityFrameworkCore.Migrations;

namespace ROBaspCore.Data.Migrations
{
    public partial class updatingSpellModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpellLevel",
                table: "SpellModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpellLevel",
                table: "SpellModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
