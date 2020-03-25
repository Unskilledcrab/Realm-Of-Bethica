using Microsoft.EntityFrameworkCore.Migrations;

namespace ROBaspCore.Data.Migrations
{
    public partial class changingDeleteBehaviorToSetNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechniqueTalentPrerequisiteLinks_TalentModel_TalentId",
                table: "TechniqueTalentPrerequisiteLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_TechniqueTalentPrerequisiteLinks_TechniqueModel_TechniqueId",
                table: "TechniqueTalentPrerequisiteLinks");

            migrationBuilder.AddForeignKey(
                name: "FK_TechniqueTalentPrerequisiteLinks_TalentModel_TalentId",
                table: "TechniqueTalentPrerequisiteLinks",
                column: "TalentId",
                principalTable: "TalentModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TechniqueTalentPrerequisiteLinks_TechniqueModel_TechniqueId",
                table: "TechniqueTalentPrerequisiteLinks",
                column: "TechniqueId",
                principalTable: "TechniqueModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechniqueTalentPrerequisiteLinks_TalentModel_TalentId",
                table: "TechniqueTalentPrerequisiteLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_TechniqueTalentPrerequisiteLinks_TechniqueModel_TechniqueId",
                table: "TechniqueTalentPrerequisiteLinks");

            migrationBuilder.AddForeignKey(
                name: "FK_TechniqueTalentPrerequisiteLinks_TalentModel_TalentId",
                table: "TechniqueTalentPrerequisiteLinks",
                column: "TalentId",
                principalTable: "TalentModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TechniqueTalentPrerequisiteLinks_TechniqueModel_TechniqueId",
                table: "TechniqueTalentPrerequisiteLinks",
                column: "TechniqueId",
                principalTable: "TechniqueModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
