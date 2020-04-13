using Microsoft.EntityFrameworkCore.Migrations;

namespace ROB.Web.Data.Migrations
{
    public partial class updatingparentskills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FirstAttributeId",
                table: "ParentSkillModel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondModifiedAttributeId",
                table: "ParentSkillModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParentSkillModel_FirstAttributeId",
                table: "ParentSkillModel",
                column: "FirstAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentSkillModel_SecondModifiedAttributeId",
                table: "ParentSkillModel",
                column: "SecondModifiedAttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentSkillModel_AttributeModel_FirstAttributeId",
                table: "ParentSkillModel",
                column: "FirstAttributeId",
                principalTable: "AttributeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentSkillModel_AttributeModel_SecondModifiedAttributeId",
                table: "ParentSkillModel",
                column: "SecondModifiedAttributeId",
                principalTable: "AttributeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParentSkillModel_AttributeModel_FirstAttributeId",
                table: "ParentSkillModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentSkillModel_AttributeModel_SecondModifiedAttributeId",
                table: "ParentSkillModel");

            migrationBuilder.DropIndex(
                name: "IX_ParentSkillModel_FirstAttributeId",
                table: "ParentSkillModel");

            migrationBuilder.DropIndex(
                name: "IX_ParentSkillModel_SecondModifiedAttributeId",
                table: "ParentSkillModel");

            migrationBuilder.DropColumn(
                name: "FirstAttributeId",
                table: "ParentSkillModel");

            migrationBuilder.DropColumn(
                name: "SecondModifiedAttributeId",
                table: "ParentSkillModel");
        }
    }
}
