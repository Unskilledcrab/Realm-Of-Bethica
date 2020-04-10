using Microsoft.EntityFrameworkCore.Migrations;

namespace ROB.Web.Data.Migrations
{
    public partial class fixForPregen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_ChildSkill_LinkModel_ChildSkillModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_ChildSkill_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_ParentSkill_LinkModel_ParentSkillModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_ParentSkill_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_Talent_LinkModel_TalentModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_Talent_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_Technique_LinkModel_TechniqueModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_Technique_LinkModel");

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_ChildSkill_LinkModel_ChildSkillModel_ChildSkillId",
                table: "PregenProfessionArchetype_ChildSkill_LinkModel",
                column: "ChildSkillId",
                principalTable: "ChildSkillModel",
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
                name: "FK_PregenProfessionArchetype_Talent_LinkModel_TalentModel_TalentId",
                table: "PregenProfessionArchetype_Talent_LinkModel",
                column: "TalentId",
                principalTable: "TalentModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_Technique_LinkModel_TechniqueModel_TechniqueId",
                table: "PregenProfessionArchetype_Technique_LinkModel",
                column: "TechniqueId",
                principalTable: "TechniqueModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_ChildSkill_LinkModel_ChildSkillModel_ChildSkillId",
                table: "PregenProfessionArchetype_ChildSkill_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_ParentSkill_LinkModel_ParentSkillModel_ParentSkillId",
                table: "PregenProfessionArchetype_ParentSkill_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_Talent_LinkModel_TalentModel_TalentId",
                table: "PregenProfessionArchetype_Talent_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_Technique_LinkModel_TechniqueModel_TechniqueId",
                table: "PregenProfessionArchetype_Technique_LinkModel");

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_ChildSkill_LinkModel_ChildSkillModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_ChildSkill_LinkModel",
                column: "PregenProfessionArchetypeId",
                principalTable: "ChildSkillModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_ParentSkill_LinkModel_ParentSkillModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_ParentSkill_LinkModel",
                column: "PregenProfessionArchetypeId",
                principalTable: "ParentSkillModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_Talent_LinkModel_TalentModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_Talent_LinkModel",
                column: "PregenProfessionArchetypeId",
                principalTable: "TalentModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_Technique_LinkModel_TechniqueModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_Technique_LinkModel",
                column: "PregenProfessionArchetypeId",
                principalTable: "TechniqueModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
