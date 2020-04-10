using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ROB.Web.Data.Migrations
{
    public partial class breakingStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeatValue",
                table: "ChildSkillModel");

            migrationBuilder.DropColumn(
                name: "BaseModifier",
                table: "AttributeModel");

            migrationBuilder.DropColumn(
                name: "CustomModifier",
                table: "AttributeModel");

            migrationBuilder.RenameColumn(
                name: "ModifierValue",
                table: "ChildSkillModel",
                newName: "ParentSkillId");

            migrationBuilder.AddColumn<int>(
                name: "HeightInches",
                table: "RaceModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LifeSpanYears",
                table: "RaceModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeightLBS",
                table: "RaceModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AttributeModel",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ParentSkillModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentSkillModel", x => x.Id);
                });

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
                name: "IX_ChildSkillModel_ParentSkillId",
                table: "ChildSkillModel",
                column: "ParentSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceAdditionalModifiersModel_RaceModelId",
                table: "RaceAdditionalModifiersModel",
                column: "RaceModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildSkillModel_ParentSkillModel_ParentSkillId",
                table: "ChildSkillModel",
                column: "ParentSkillId",
                principalTable: "ParentSkillModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildSkillModel_ParentSkillModel_ParentSkillId",
                table: "ChildSkillModel");

            migrationBuilder.DropTable(
                name: "ParentSkillModel");

            migrationBuilder.DropTable(
                name: "RaceAdditionalModifiersModel");

            migrationBuilder.DropIndex(
                name: "IX_ChildSkillModel_ParentSkillId",
                table: "ChildSkillModel");

            migrationBuilder.DropColumn(
                name: "HeightInches",
                table: "RaceModel");

            migrationBuilder.DropColumn(
                name: "LifeSpanYears",
                table: "RaceModel");

            migrationBuilder.DropColumn(
                name: "WeightLBS",
                table: "RaceModel");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AttributeModel");

            migrationBuilder.RenameColumn(
                name: "ParentSkillId",
                table: "ChildSkillModel",
                newName: "ModifierValue");

            migrationBuilder.AddColumn<int>(
                name: "FeatValue",
                table: "ChildSkillModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseModifier",
                table: "AttributeModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomModifier",
                table: "AttributeModel",
                nullable: false,
                defaultValue: 0);
        }
    }
}
