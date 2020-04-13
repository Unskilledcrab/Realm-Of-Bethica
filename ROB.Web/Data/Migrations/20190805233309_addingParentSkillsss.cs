using Microsoft.EntityFrameworkCore.Migrations;

namespace ROB.Web.Data.Migrations
{
    public partial class addingParentSkillsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParentSkillModel_AttributeModel_SecondModifiedAttributeId",
                table: "ParentSkillModel");

            migrationBuilder.RenameColumn(
                name: "SecondModifiedAttributeId",
                table: "ParentSkillModel",
                newName: "SecondAttributeId");

            migrationBuilder.RenameIndex(
                name: "IX_ParentSkillModel_SecondModifiedAttributeId",
                table: "ParentSkillModel",
                newName: "IX_ParentSkillModel_SecondAttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentSkillModel_AttributeModel_SecondAttributeId",
                table: "ParentSkillModel",
                column: "SecondAttributeId",
                principalTable: "AttributeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParentSkillModel_AttributeModel_SecondAttributeId",
                table: "ParentSkillModel");

            migrationBuilder.RenameColumn(
                name: "SecondAttributeId",
                table: "ParentSkillModel",
                newName: "SecondModifiedAttributeId");

            migrationBuilder.RenameIndex(
                name: "IX_ParentSkillModel_SecondAttributeId",
                table: "ParentSkillModel",
                newName: "IX_ParentSkillModel_SecondModifiedAttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentSkillModel_AttributeModel_SecondModifiedAttributeId",
                table: "ParentSkillModel",
                column: "SecondModifiedAttributeId",
                principalTable: "AttributeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
