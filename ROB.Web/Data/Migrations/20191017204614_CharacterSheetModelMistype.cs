using Microsoft.EntityFrameworkCore.Migrations;

namespace ROB.Web.Data.Migrations
{
    public partial class CharacterSheetModelMistype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HeadStrongModifier",
                table: "CharacterSheetModel",
                newName: "HeadstrongModifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HeadstrongModifier",
                table: "CharacterSheetModel",
                newName: "HeadStrongModifier");
        }
    }
}
