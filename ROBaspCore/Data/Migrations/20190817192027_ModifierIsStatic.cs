using Microsoft.EntityFrameworkCore.Migrations;

namespace ROBaspCore.Data.Migrations
{
    public partial class ModifierIsStatic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsStatic",
                table: "ModifierModel",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsStatic",
                table: "ModifierModel",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
