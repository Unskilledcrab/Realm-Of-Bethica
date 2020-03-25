using Microsoft.EntityFrameworkCore.Migrations;

namespace ROBaspCore.Data.Migrations
{
    public partial class TalentGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TalentModel_TalentGroupTypeModel_TalentGroupId",
                table: "TalentModel");

            migrationBuilder.AlterColumn<int>(
                name: "TalentGroupId",
                table: "TalentModel",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentModel_TalentGroupTypeModel_TalentGroupId",
                table: "TalentModel",
                column: "TalentGroupId",
                principalTable: "TalentGroupTypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TalentModel_TalentGroupTypeModel_TalentGroupId",
                table: "TalentModel");

            migrationBuilder.AlterColumn<int>(
                name: "TalentGroupId",
                table: "TalentModel",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TalentModel_TalentGroupTypeModel_TalentGroupId",
                table: "TalentModel",
                column: "TalentGroupId",
                principalTable: "TalentGroupTypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
