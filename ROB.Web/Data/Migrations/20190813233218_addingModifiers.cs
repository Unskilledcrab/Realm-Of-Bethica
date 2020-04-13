using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ROB.Web.Data.Migrations
{
    public partial class addingModifiers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildSkillsModifier");

            migrationBuilder.DropTable(
                name: "ParentSkillsModifier");

            migrationBuilder.DropTable(
                name: "RaceAdditionalModifierModel");

            migrationBuilder.AddColumn<int>(
                name: "Cost",
                table: "TechniqueModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinimumLevelRequirement",
                table: "TechniqueModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cost",
                table: "TalentModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cost",
                table: "ParentSkillModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cost",
                table: "ChildSkillModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ModifierModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ChildSkillToModifyId = table.Column<int>(nullable: true),
                    ParentSkillToModifyId = table.Column<int>(nullable: true),
                    AttributeToModifyId = table.Column<int>(nullable: true),
                    EffectAllParentSkills = table.Column<bool>(nullable: false),
                    EffectAllTrainedParentSkills = table.Column<bool>(nullable: false),
                    MultiplyByLevel = table.Column<bool>(nullable: false),
                    AdditionalModifiers = table.Column<string>(nullable: true),
                    Modifier = table.Column<int>(nullable: false),
                    RaceModelId = table.Column<int>(nullable: true),
                    TechniqueModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModifierModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModifierModel_AttributeModel_AttributeToModifyId",
                        column: x => x.AttributeToModifyId,
                        principalTable: "AttributeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModifierModel_ChildSkillModel_ChildSkillToModifyId",
                        column: x => x.ChildSkillToModifyId,
                        principalTable: "ChildSkillModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModifierModel_ParentSkillModel_ParentSkillToModifyId",
                        column: x => x.ParentSkillToModifyId,
                        principalTable: "ParentSkillModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModifierModel_RaceModel_RaceModelId",
                        column: x => x.RaceModelId,
                        principalTable: "RaceModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModifierModel_TechniqueModel_TechniqueModelId",
                        column: x => x.TechniqueModelId,
                        principalTable: "TechniqueModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModifierModel_AttributeToModifyId",
                table: "ModifierModel",
                column: "AttributeToModifyId");

            migrationBuilder.CreateIndex(
                name: "IX_ModifierModel_ChildSkillToModifyId",
                table: "ModifierModel",
                column: "ChildSkillToModifyId");

            migrationBuilder.CreateIndex(
                name: "IX_ModifierModel_ParentSkillToModifyId",
                table: "ModifierModel",
                column: "ParentSkillToModifyId");

            migrationBuilder.CreateIndex(
                name: "IX_ModifierModel_RaceModelId",
                table: "ModifierModel",
                column: "RaceModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModifierModel_TechniqueModelId",
                table: "ModifierModel",
                column: "TechniqueModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModifierModel");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "TechniqueModel");

            migrationBuilder.DropColumn(
                name: "MinimumLevelRequirement",
                table: "TechniqueModel");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "TalentModel");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "ParentSkillModel");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "ChildSkillModel");

            migrationBuilder.CreateTable(
                name: "ChildSkillsModifier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChildSkillToModifyId = table.Column<int>(nullable: true),
                    Modifier = table.Column<int>(nullable: false),
                    RaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildSkillsModifier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildSkillsModifier_ChildSkillModel_ChildSkillToModifyId",
                        column: x => x.ChildSkillToModifyId,
                        principalTable: "ChildSkillModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChildSkillsModifier_RaceModel_RaceId",
                        column: x => x.RaceId,
                        principalTable: "RaceModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParentSkillsModifier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Modifier = table.Column<int>(nullable: false),
                    ParentSkillToModifyId = table.Column<int>(nullable: true),
                    RaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentSkillsModifier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParentSkillsModifier_ParentSkillModel_ParentSkillToModifyId",
                        column: x => x.ParentSkillToModifyId,
                        principalTable: "ParentSkillModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParentSkillsModifier_RaceModel_RaceId",
                        column: x => x.RaceId,
                        principalTable: "RaceModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceAdditionalModifierModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModifierDescription = table.Column<string>(nullable: true),
                    RaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceAdditionalModifierModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceAdditionalModifierModel_RaceModel_RaceId",
                        column: x => x.RaceId,
                        principalTable: "RaceModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildSkillsModifier_ChildSkillToModifyId",
                table: "ChildSkillsModifier",
                column: "ChildSkillToModifyId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildSkillsModifier_RaceId",
                table: "ChildSkillsModifier",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentSkillsModifier_ParentSkillToModifyId",
                table: "ParentSkillsModifier",
                column: "ParentSkillToModifyId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentSkillsModifier_RaceId",
                table: "ParentSkillsModifier",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceAdditionalModifierModel_RaceId",
                table: "RaceAdditionalModifierModel",
                column: "RaceId");
        }
    }
}
