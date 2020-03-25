using Microsoft.EntityFrameworkCore.Migrations;

namespace ROBaspCore.Data.Migrations
{
    public partial class undo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_ParentSkill_LinkModel_ParentSkillModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_ParentSkill_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_ParentSkill_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_ParentSkill_LinkModel");

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_ParentSkill_LinkModel_ParentSkillModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_ParentSkill_LinkModel",
                column: "PregenProfessionArchetypeId",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_ParentSkill_LinkModel_ParentSkillModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_ParentSkill_LinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PregenProfessionArchetype_ParentSkill_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_ParentSkill_LinkModel");

            migrationBuilder.AddForeignKey(
                name: "FK_PregenProfessionArchetype_ParentSkill_LinkModel_ParentSkillModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_ParentSkill_LinkModel",
                column: "PregenProfessionArchetypeId",
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
        }
    }
}
