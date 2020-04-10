using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ROB.Web.Data.Migrations
{
    public partial class cleanUpUnusedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechniqueGameRequirementsLink");

            migrationBuilder.DropTable(
                name: "TechniqueGameRequirement");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TechniqueGameRequirement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    DescriptionBrief = table.Column<string>(nullable: true),
                    TechniqueGroupTypeId = table.Column<int>(nullable: false)
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
                name: "TechniqueGameRequirementsLink",
                columns: table => new
                {
                    GameRequirementId = table.Column<int>(nullable: false),
                    TechniqueId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_TechniqueGameRequirement_TechniqueGroupTypeId",
                table: "TechniqueGameRequirement",
                column: "TechniqueGroupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TechniqueGameRequirementsLink_TechniqueId",
                table: "TechniqueGameRequirementsLink",
                column: "TechniqueId");
        }
    }
}
