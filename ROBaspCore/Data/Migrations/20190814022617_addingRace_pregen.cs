using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ROBaspCore.Data.Migrations
{
    public partial class addingRace_pregen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "ParentSkillModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PregenProfessionArchetypeModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregenProfessionArchetypeModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PregenProfessionArchetype_ChildSkill_LinkModel",
                columns: table => new
                {
                    PregenProfessionArchetypeId = table.Column<int>(nullable: false),
                    ChildSkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregenProfessionArchetype_ChildSkill_LinkModel", x => new { x.ChildSkillId, x.PregenProfessionArchetypeId });
                    table.ForeignKey(
                        name: "FK_PregenProfessionArchetype_ChildSkill_LinkModel_ChildSkillModel_PregenProfessionArchetypeId",
                        column: x => x.PregenProfessionArchetypeId,
                        principalTable: "ChildSkillModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PregenProfessionArchetype_ChildSkill_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                        column: x => x.PregenProfessionArchetypeId,
                        principalTable: "PregenProfessionArchetypeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PregenProfessionArchetype_ParentSkill_LinkModel",
                columns: table => new
                {
                    PregenProfessionArchetypeId = table.Column<int>(nullable: false),
                    ParentSkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregenProfessionArchetype_ParentSkill_LinkModel", x => new { x.ParentSkillId, x.PregenProfessionArchetypeId });
                    table.ForeignKey(
                        name: "FK_PregenProfessionArchetype_ParentSkill_LinkModel_ParentSkillModel_PregenProfessionArchetypeId",
                        column: x => x.PregenProfessionArchetypeId,
                        principalTable: "ParentSkillModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PregenProfessionArchetype_ParentSkill_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                        column: x => x.PregenProfessionArchetypeId,
                        principalTable: "PregenProfessionArchetypeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PregenProfessionArchetype_Talent_LinkModel",
                columns: table => new
                {
                    PregenProfessionArchetypeId = table.Column<int>(nullable: false),
                    TalentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregenProfessionArchetype_Talent_LinkModel", x => new { x.TalentId, x.PregenProfessionArchetypeId });
                    table.ForeignKey(
                        name: "FK_PregenProfessionArchetype_Talent_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                        column: x => x.PregenProfessionArchetypeId,
                        principalTable: "PregenProfessionArchetypeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PregenProfessionArchetype_Talent_LinkModel_TalentModel_PregenProfessionArchetypeId",
                        column: x => x.PregenProfessionArchetypeId,
                        principalTable: "TalentModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PregenProfessionArchetype_Technique_LinkModel",
                columns: table => new
                {
                    PregenProfessionArchetypeId = table.Column<int>(nullable: false),
                    TechniqueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregenProfessionArchetype_Technique_LinkModel", x => new { x.TechniqueId, x.PregenProfessionArchetypeId });
                    table.ForeignKey(
                        name: "FK_PregenProfessionArchetype_Technique_LinkModel_PregenProfessionArchetypeModel_PregenProfessionArchetypeId",
                        column: x => x.PregenProfessionArchetypeId,
                        principalTable: "PregenProfessionArchetypeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PregenProfessionArchetype_Technique_LinkModel_TechniqueModel_PregenProfessionArchetypeId",
                        column: x => x.PregenProfessionArchetypeId,
                        principalTable: "TechniqueModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PregenProfessionArchetype_ChildSkill_LinkModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_ChildSkill_LinkModel",
                column: "PregenProfessionArchetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PregenProfessionArchetype_ParentSkill_LinkModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_ParentSkill_LinkModel",
                column: "PregenProfessionArchetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PregenProfessionArchetype_Talent_LinkModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_Talent_LinkModel",
                column: "PregenProfessionArchetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PregenProfessionArchetype_Technique_LinkModel_PregenProfessionArchetypeId",
                table: "PregenProfessionArchetype_Technique_LinkModel",
                column: "PregenProfessionArchetypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PregenProfessionArchetype_ChildSkill_LinkModel");

            migrationBuilder.DropTable(
                name: "PregenProfessionArchetype_ParentSkill_LinkModel");

            migrationBuilder.DropTable(
                name: "PregenProfessionArchetype_Talent_LinkModel");

            migrationBuilder.DropTable(
                name: "PregenProfessionArchetype_Technique_LinkModel");

            migrationBuilder.DropTable(
                name: "PregenProfessionArchetypeModel");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "ParentSkillModel");
        }
    }
}
