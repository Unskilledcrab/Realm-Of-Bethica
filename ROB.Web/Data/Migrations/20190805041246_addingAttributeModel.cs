using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ROB.Web.Data.Migrations
{
    public partial class addingAttributeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeModel_RaceModel_RaceModelId",
                table: "AttributeModel");

            migrationBuilder.DropTable(
                name: "RaceAdditionalModifiersModel");

            migrationBuilder.DropIndex(
                name: "IX_AttributeModel_RaceModelId",
                table: "AttributeModel");

            migrationBuilder.DropColumn(
                name: "RaceModelId",
                table: "AttributeModel");

            migrationBuilder.AddColumn<int>(
                name: "FirstAttributeModifier",
                table: "RaceModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FirstModifiedAttributeId",
                table: "RaceModel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondAttributeModifier",
                table: "RaceModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondModifiedAttributeId",
                table: "RaceModel",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChildSkillsModifier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RaceId = table.Column<int>(nullable: false),
                    ChildSkillToModifyId = table.Column<int>(nullable: true),
                    Modifier = table.Column<int>(nullable: false)
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
                    RaceId = table.Column<int>(nullable: false),
                    ParentSkillToModifyId = table.Column<int>(nullable: true),
                    Modifier = table.Column<int>(nullable: false)
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
                    RaceId = table.Column<int>(nullable: false),
                    ModifierDescription = table.Column<string>(nullable: true)
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
                name: "IX_RaceModel_FirstModifiedAttributeId",
                table: "RaceModel",
                column: "FirstModifiedAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceModel_SecondModifiedAttributeId",
                table: "RaceModel",
                column: "SecondModifiedAttributeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_RaceModel_AttributeModel_FirstModifiedAttributeId",
                table: "RaceModel",
                column: "FirstModifiedAttributeId",
                principalTable: "AttributeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceModel_AttributeModel_SecondModifiedAttributeId",
                table: "RaceModel",
                column: "SecondModifiedAttributeId",
                principalTable: "AttributeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceModel_AttributeModel_FirstModifiedAttributeId",
                table: "RaceModel");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceModel_AttributeModel_SecondModifiedAttributeId",
                table: "RaceModel");

            migrationBuilder.DropTable(
                name: "ChildSkillsModifier");

            migrationBuilder.DropTable(
                name: "ParentSkillsModifier");

            migrationBuilder.DropTable(
                name: "RaceAdditionalModifierModel");

            migrationBuilder.DropIndex(
                name: "IX_RaceModel_FirstModifiedAttributeId",
                table: "RaceModel");

            migrationBuilder.DropIndex(
                name: "IX_RaceModel_SecondModifiedAttributeId",
                table: "RaceModel");

            migrationBuilder.DropColumn(
                name: "FirstAttributeModifier",
                table: "RaceModel");

            migrationBuilder.DropColumn(
                name: "FirstModifiedAttributeId",
                table: "RaceModel");

            migrationBuilder.DropColumn(
                name: "SecondAttributeModifier",
                table: "RaceModel");

            migrationBuilder.DropColumn(
                name: "SecondModifiedAttributeId",
                table: "RaceModel");

            migrationBuilder.AddColumn<int>(
                name: "RaceModelId",
                table: "AttributeModel",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RaceAdditionalModifiersModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModifierDescription = table.Column<string>(nullable: true),
                    RaceModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceAdditionalModifiersModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceAdditionalModifiersModel_RaceModel_RaceModelId",
                        column: x => x.RaceModelId,
                        principalTable: "RaceModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeModel_RaceModelId",
                table: "AttributeModel",
                column: "RaceModelId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceAdditionalModifiersModel_RaceModelId",
                table: "RaceAdditionalModifiersModel",
                column: "RaceModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeModel_RaceModel_RaceModelId",
                table: "AttributeModel",
                column: "RaceModelId",
                principalTable: "RaceModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
