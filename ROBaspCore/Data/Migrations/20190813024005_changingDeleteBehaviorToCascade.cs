using Microsoft.EntityFrameworkCore.Migrations;

namespace ROBaspCore.Data.Migrations
{
    public partial class changingDeleteBehaviorToCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechniqueGameRequirementsLink_TechniqueGameRequirement_GameRequirementId",
                table: "TechniqueGameRequirementsLink");

            migrationBuilder.AddForeignKey(
                name: "FK_TechniqueGameRequirementsLink_TechniqueGameRequirement_GameRequirementId",
                table: "TechniqueGameRequirementsLink",
                column: "GameRequirementId",
                principalTable: "TechniqueGameRequirement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechniqueGameRequirementsLink_TechniqueGameRequirement_GameRequirementId",
                table: "TechniqueGameRequirementsLink");

            migrationBuilder.AddForeignKey(
                name: "FK_TechniqueGameRequirementsLink_TechniqueGameRequirement_GameRequirementId",
                table: "TechniqueGameRequirementsLink",
                column: "GameRequirementId",
                principalTable: "TechniqueGameRequirement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
