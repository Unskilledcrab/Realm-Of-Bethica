using Microsoft.EntityFrameworkCore.Migrations;

namespace ROBaspCore.Data.Migrations
{
    public partial class changingBackToCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_ChildSkill_LinkModel_ChildSkillModel_ChildSkillId",
                table: "PregenProfessionArchetype_ChildSkill_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_ChildSkill_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_ChildSkill_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_ParentSkill_LinkModel_ParentSkillModel_ParentSkillId",
                table: "PregenProfessionArchetype_ParentSkill_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_ParentSkill_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_ParentSkill_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_Talent_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_Talent_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_Talent_LinkModel_TalentModel_TalentId",
                table: "PregenProfessionArchetype_Talent_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_Technique_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_Technique_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_Technique_LinkModel_TechniqueModel_TechniqueId",
                table: "PregenProfessionArchetype_Technique_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TechniqueGameRequirementsLink_TechniqueGameRequirement_GameRequirementId",
                table: "TechniqueGameRequirementsLink");

            migrationBuilder.AddColumn<bool>(
                name: "IsStatic",
                table: "ModifierModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaticSkillSufix",
                table: "ModifierModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaticSkillToModify",
                table: "ModifierModel",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_ChildSkill_LinkModel_ChildSkillModel_ChildSkillId",
                table: "PregenProfessionArchetype_ChildSkill_LinkModel",
                column: "ChildSkillId",
                principalTable: "ChildSkillModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_ChildSkill_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_ChildSkill_LinkModel",
                column: "PregenProfessionArchetypeId",
                principalTable: "PregenProfessionArchetypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_ParentSkill_LinkModel_ParentSkillModel_ParentSkillId",
                table: "PregenProfessionArchetype_ParentSkill_LinkModel",
                column: "ParentSkillId",
                principalTable: "ParentSkillModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_ParentSkill_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_ParentSkill_LinkModel",
                column: "PregenProfessionArchetypeId",
                principalTable: "PregenProfessionArchetypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_Talent_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_Talent_LinkModel",
                column: "PregenProfessionArchetypeId",
                principalTable: "PregenProfessionArchetypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_Talent_LinkModel_TalentModel_TalentId",
                table: "PregenProfessionArchetype_Talent_LinkModel",
                column: "TalentId",
                principalTable: "TalentModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_Technique_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_Technique_LinkModel",
                column: "PregenProfessionArchetypeId",
                principalTable: "PregenProfessionArchetypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_Technique_LinkModel_TechniqueModel_TechniqueId",
                table: "PregenProfessionArchetype_Technique_LinkModel",
                column: "TechniqueId",
                principalTable: "TechniqueModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TechniqueGameRequirementsLink_TechniqueGameRequirement_GameRequirementId",
                table: "TechniqueGameRequirementsLink",
                column: "GameRequirementId",
                principalTable: "TechniqueGameRequirement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_ChildSkill_LinkModel_ChildSkillModel_ChildSkillId",
                table: "PregenProfessionArchetype_ChildSkill_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_ChildSkill_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_ChildSkill_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_ParentSkill_LinkModel_ParentSkillModel_ParentSkillId",
                table: "PregenProfessionArchetype_ParentSkill_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_ParentSkill_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_ParentSkill_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_Talent_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_Talent_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_Talent_LinkModel_TalentModel_TalentId",
                table: "PregenProfessionArchetype_Talent_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_Technique_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_Technique_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_Technique_LinkModel_TechniqueModel_TechniqueId",
                table: "PregenProfessionArchetype_Technique_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TechniqueGameRequirementsLink_TechniqueGameRequirement_GameRequirementId",
                table: "TechniqueGameRequirementsLink");

            migrationBuilder.DropColumn(
                name: "IsStatic",
                table: "ModifierModel");

            migrationBuilder.DropColumn(
                name: "StaticSkillSufix",
                table: "ModifierModel");

            migrationBuilder.DropColumn(
                name: "StaticSkillToModify",
                table: "ModifierModel");

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_ChildSkill_LinkModel_ChildSkillModel_ChildSkillId",
                table: "PregenProfessionArchetype_ChildSkill_LinkModel",
                column: "ChildSkillId",
                principalTable: "ChildSkillModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_ChildSkill_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_ChildSkill_LinkModel",
                column: "PregenProfessionArchetypeId",
                principalTable: "PregenProfessionArchetypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_ParentSkill_LinkModel_ParentSkillModel_ParentSkillId",
                table: "PregenProfessionArchetype_ParentSkill_LinkModel",
                column: "ParentSkillId",
                principalTable: "ParentSkillModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_ParentSkill_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_ParentSkill_LinkModel",
                column: "PregenProfessionArchetypeId",
                principalTable: "PregenProfessionArchetypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_Talent_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_Talent_LinkModel",
                column: "PregenProfessionArchetypeId",
                principalTable: "PregenProfessionArchetypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_Talent_LinkModel_TalentModel_TalentId",
                table: "PregenProfessionArchetype_Talent_LinkModel",
                column: "TalentId",
                principalTable: "TalentModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_Technique_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_Technique_LinkModel",
                column: "PregenProfessionArchetypeId",
                principalTable: "PregenProfessionArchetypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_Technique_LinkModel_TechniqueModel_TechniqueId",
                table: "PregenProfessionArchetype_Technique_LinkModel",
                column: "TechniqueId",
                principalTable: "TechniqueModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TechniqueGameRequirementsLink_TechniqueGameRequirement_GameRequirementId",
                table: "TechniqueGameRequirementsLink",
                column: "GameRequirementId",
                principalTable: "TechniqueGameRequirement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
