using Microsoft.EntityFrameworkCore.Migrations;

namespace ROBaspCore.Data.Migrations
{
    public partial class updateLanguageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LanguageModel_LanguageGroupTypeModel_GroupTypeId",
                table: "LanguageModel");

            migrationBuilder.AlterColumn<int>(
                name: "GroupTypeId",
                table: "LanguageModel",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageModel_LanguageGroupTypeModel_GroupTypeId",
                table: "LanguageModel",
                column: "GroupTypeId",
                principalTable: "LanguageGroupTypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LanguageModel_LanguageGroupTypeModel_GroupTypeId",
                table: "LanguageModel");

            migrationBuilder.AlterColumn<int>(
                name: "GroupTypeId",
                table: "LanguageModel",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageModel_LanguageGroupTypeModel_GroupTypeId",
                table: "LanguageModel",
                column: "GroupTypeId",
                principalTable: "LanguageGroupTypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
