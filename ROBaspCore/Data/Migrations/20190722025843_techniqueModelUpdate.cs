using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ROBaspCore.Data.Migrations
{
    public partial class techniqueModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TechniqueGameRequirement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TechniqueGroupTypeId = table.Column<int>(nullable: false),
                    DescriptionBrief = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechniqueGameRequirement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechniqueGameRequirement_TechniqueGroupTypeModel_TechniqueGroupTypeId",
                        column: x => x.TechniqueGroupTypeId,
                        principalTable: "TechniqueGroupTypeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechniqueModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TechniqueGroupTypeId = table.Column<int>(nullable: false),
                    TechniqueName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DurationLengthType = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechniqueModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechniqueModel_TechniqueGroupTypeModel_TechniqueGroupTypeId",
                        column: x => x.TechniqueGroupTypeId,
                        principalTable: "TechniqueGroupTypeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechniqueGameRequirementsLink",
                columns: table => new
                {
                    TechniqueId = table.Column<int>(nullable: false),
                    GameRequirementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechniqueGameRequirementsLink", x => new { x.GameRequirementId, x.TechniqueId });
                    table.ForeignKey(
                        name: "FK_TechniqueGameRequirementsLink_TechniqueGameRequirement_GameRequirementId",
                        column: x => x.GameRequirementId,
                        principalTable: "TechniqueGameRequirement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TechniqueGameRequirementsLink_TechniqueModel_TechniqueId",
                        column: x => x.TechniqueId,
                        principalTable: "TechniqueModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TechniquePrerequisitesLink",
                columns: table => new
                {
                    TechniqueModelId = table.Column<int>(nullable: false),
                    PrerequisiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechniquePrerequisitesLink", x => new { x.TechniqueModelId, x.PrerequisiteId });
                    table.ForeignKey(
                        name: "FK_TechniquePrerequisitesLink_TechniqueModel_PrerequisiteId",
                        column: x => x.PrerequisiteId,
                        principalTable: "TechniqueModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TechniquePrerequisitesLink_TechniqueModel_TechniqueModelId",
                        column: x => x.TechniqueModelId,
                        principalTable: "TechniqueModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechniqueGameRequirement_TechniqueGroupTypeId",
                table: "TechniqueGameRequirement",
                column: "TechniqueGroupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TechniqueGameRequirementsLink_TechniqueId",
                table: "TechniqueGameRequirementsLink",
                column: "TechniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_TechniqueModel_TechniqueGroupTypeId",
                table: "TechniqueModel",
                column: "TechniqueGroupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TechniquePrerequisitesLink_PrerequisiteId",
                table: "TechniquePrerequisitesLink",
                column: "PrerequisiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechniqueGameRequirementsLink");

            migrationBuilder.DropTable(
                name: "TechniquePrerequisitesLink");

            migrationBuilder.DropTable(
                name: "TechniqueGameRequirement");

            migrationBuilder.DropTable(
                name: "TechniqueModel");
        }
    }
}
