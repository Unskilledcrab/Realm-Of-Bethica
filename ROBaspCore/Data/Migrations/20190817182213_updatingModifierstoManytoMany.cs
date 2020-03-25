using Microsoft.EntityFrameworkCore.Migrations;

namespace ROBaspCore.Data.Migrations
{
    public partial class updatingModifierstoManytoMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModifierModel_RaceModel_RaceModelId",
                table: "ModifierModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ModifierModel_TechniqueModel_TechniqueModelId",
                table: "ModifierModel");

            migrationBuilder.DropIndex(
                name: "IX_ModifierModel_RaceModelId",
                table: "ModifierModel");

            migrationBuilder.DropIndex(
                name: "IX_ModifierModel_TechniqueModelId",
                table: "ModifierModel");

            migrationBuilder.DropColumn(
                name: "RaceModelId",
                table: "ModifierModel");

            migrationBuilder.DropColumn(
                name: "TechniqueModelId",
                table: "ModifierModel");

            migrationBuilder.CreateTable(
                name: "Modifier_Race_Link",
                columns: table => new
                {
                    ModifierId = table.Column<int>(nullable: false),
                    RaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modifier_Race_Link", x => new { x.ModifierId, x.RaceId });
                    table.ForeignKey(
                        name: "FK_Modifier_Race_Link_ModifierModel_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "ModifierModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Modifier_Race_Link_RaceModel_RaceId",
                        column: x => x.RaceId,
                        principalTable: "RaceModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modifier_Technique_Link",
                columns: table => new
                {
                    ModifierId = table.Column<int>(nullable: false),
                    TechniqueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modifier_Technique_Link", x => new { x.ModifierId, x.TechniqueId });
                    table.ForeignKey(
                        name: "FK_Modifier_Technique_Link_ModifierModel_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "ModifierModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Modifier_Technique_Link_TechniqueModel_TechniqueId",
                        column: x => x.TechniqueId,
                        principalTable: "TechniqueModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modifier_Race_Link_RaceId",
                table: "Modifier_Race_Link",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Modifier_Technique_Link_TechniqueId",
                table: "Modifier_Technique_Link",
                column: "TechniqueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modifier_Race_Link");

            migrationBuilder.DropTable(
                name: "Modifier_Technique_Link");

            migrationBuilder.AddColumn<int>(
                name: "RaceModelId",
                table: "ModifierModel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TechniqueModelId",
                table: "ModifierModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModifierModel_RaceModelId",
                table: "ModifierModel",
                column: "RaceModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModifierModel_TechniqueModelId",
                table: "ModifierModel",
                column: "TechniqueModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModifierModel_RaceModel_RaceModelId",
                table: "ModifierModel",
                column: "RaceModelId",
                principalTable: "RaceModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModifierModel_TechniqueModel_TechniqueModelId",
                table: "ModifierModel",
                column: "TechniqueModelId",
                principalTable: "TechniqueModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
