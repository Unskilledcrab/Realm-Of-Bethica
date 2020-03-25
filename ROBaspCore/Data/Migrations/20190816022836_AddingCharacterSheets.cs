using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ROBaspCore.Data.Migrations
{
    public partial class AddingCharacterSheets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterSheetModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RaceId = table.Column<int>(nullable: true),
                    Strong = table.Column<int>(nullable: false),
                    Robust = table.Column<int>(nullable: false),
                    Agile = table.Column<int>(nullable: false),
                    Precision = table.Column<int>(nullable: false),
                    Knowledgeable = table.Column<int>(nullable: false),
                    Headstrong = table.Column<int>(nullable: false),
                    Charismatic = table.Column<int>(nullable: false),
                    Attractive = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheetModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterSheetModel_RaceModel_RaceId",
                        column: x => x.RaceId,
                        principalTable: "RaceModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSheet_ChildSkill_Link",
                columns: table => new
                {
                    CharacterSheetId = table.Column<int>(nullable: false),
                    ChildSkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheet_ChildSkill_Link", x => new { x.CharacterSheetId, x.ChildSkillId });
                    table.ForeignKey(
                        name: "FK_CharacterSheet_ChildSkill_Link_CharacterSheetModel_CharacterSheetId",
                        column: x => x.CharacterSheetId,
                        principalTable: "CharacterSheetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSheet_ChildSkill_Link_ChildSkillModel_ChildSkillId",
                        column: x => x.ChildSkillId,
                        principalTable: "ChildSkillModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSheet_ParentSkill_Link",
                columns: table => new
                {
                    CharacterSheetId = table.Column<int>(nullable: false),
                    ParentSkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheet_ParentSkill_Link", x => new { x.CharacterSheetId, x.ParentSkillId });
                    table.ForeignKey(
                        name: "FK_CharacterSheet_ParentSkill_Link_CharacterSheetModel_CharacterSheetId",
                        column: x => x.CharacterSheetId,
                        principalTable: "CharacterSheetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSheet_ParentSkill_Link_ParentSkillModel_ParentSkillId",
                        column: x => x.ParentSkillId,
                        principalTable: "ParentSkillModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSheet_Talent_Link",
                columns: table => new
                {
                    CharacterSheetId = table.Column<int>(nullable: false),
                    TalentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheet_Talent_Link", x => new { x.CharacterSheetId, x.TalentId });
                    table.ForeignKey(
                        name: "FK_CharacterSheet_Talent_Link_CharacterSheetModel_CharacterSheetId",
                        column: x => x.CharacterSheetId,
                        principalTable: "CharacterSheetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSheet_Talent_Link_TalentModel_TalentId",
                        column: x => x.TalentId,
                        principalTable: "TalentModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSheet_Technique_Link",
                columns: table => new
                {
                    CharacterSheetId = table.Column<int>(nullable: false),
                    TechniqueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheet_Technique_Link", x => new { x.CharacterSheetId, x.TechniqueId });
                    table.ForeignKey(
                        name: "FK_CharacterSheet_Technique_Link_CharacterSheetModel_CharacterSheetId",
                        column: x => x.CharacterSheetId,
                        principalTable: "CharacterSheetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSheet_Technique_Link_TechniqueModel_TechniqueId",
                        column: x => x.TechniqueId,
                        principalTable: "TechniqueModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheet_ChildSkill_Link_ChildSkillId",
                table: "CharacterSheet_ChildSkill_Link",
                column: "ChildSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheet_ParentSkill_Link_ParentSkillId",
                table: "CharacterSheet_ParentSkill_Link",
                column: "ParentSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheet_Talent_Link_TalentId",
                table: "CharacterSheet_Talent_Link",
                column: "TalentId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheet_Technique_Link_TechniqueId",
                table: "CharacterSheet_Technique_Link",
                column: "TechniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheetModel_RaceId",
                table: "CharacterSheetModel",
                column: "RaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterSheet_ChildSkill_Link");

            migrationBuilder.DropTable(
                name: "CharacterSheet_ParentSkill_Link");

            migrationBuilder.DropTable(
                name: "CharacterSheet_Talent_Link");

            migrationBuilder.DropTable(
                name: "CharacterSheet_Technique_Link");

            migrationBuilder.DropTable(
                name: "CharacterSheetModel");
        }
    }
}
