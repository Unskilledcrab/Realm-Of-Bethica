using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ROB.Web.Data.Migrations
{
    public partial class techniqueTalentPrereqs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TalentGroupTypeModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentGroupTypeModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TalentModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TalentGroupId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Benefit = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TalentModel_TalentGroupTypeModel_TalentGroupId",
                        column: x => x.TalentGroupId,
                        principalTable: "TalentGroupTypeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TalentPrerequisiteLink",
                columns: table => new
                {
                    TalentId = table.Column<int>(nullable: false),
                    PrerequisiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentPrerequisiteLink", x => new { x.TalentId, x.PrerequisiteId });
                    table.ForeignKey(
                        name: "FK_TalentPrerequisiteLink_TalentModel_PrerequisiteId",
                        column: x => x.PrerequisiteId,
                        principalTable: "TalentModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TalentPrerequisiteLink_TalentModel_TalentId",
                        column: x => x.TalentId,
                        principalTable: "TalentModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TechniqueTalentPrerequisiteLinks",
                columns: table => new
                {
                    TalentId = table.Column<int>(nullable: false),
                    TechniqueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechniqueTalentPrerequisiteLinks", x => new { x.TalentId, x.TechniqueId });
                    table.ForeignKey(
                        name: "FK_TechniqueTalentPrerequisiteLinks_TalentModel_TalentId",
                        column: x => x.TalentId,
                        principalTable: "TalentModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TechniqueTalentPrerequisiteLinks_TechniqueModel_TechniqueId",
                        column: x => x.TechniqueId,
                        principalTable: "TechniqueModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TalentModel_TalentGroupId",
                table: "TalentModel",
                column: "TalentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TalentPrerequisiteLink_PrerequisiteId",
                table: "TalentPrerequisiteLink",
                column: "PrerequisiteId");

            migrationBuilder.CreateIndex(
                name: "IX_TechniqueTalentPrerequisiteLinks_TechniqueId",
                table: "TechniqueTalentPrerequisiteLinks",
                column: "TechniqueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TalentPrerequisiteLink");

            migrationBuilder.DropTable(
                name: "TechniqueTalentPrerequisiteLinks");

            migrationBuilder.DropTable(
                name: "TalentModel");

            migrationBuilder.DropTable(
                name: "TalentGroupTypeModel");
        }
    }
}
