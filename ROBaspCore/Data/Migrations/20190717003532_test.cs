using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ROBaspCore.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "LanguageModel");

            migrationBuilder.RenameColumn(
                name: "CustomModifer",
                table: "AttributeModel",
                newName: "CustomModifier");

            migrationBuilder.AddColumn<int>(
                name: "GroupTypeId",
                table: "LanguageModel",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LanguageGroupTypeModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LanguageType = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageGroupTypeModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageModel_GroupTypeId",
                table: "LanguageModel",
                column: "GroupTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageModel_LanguageGroupTypeModel_GroupTypeId",
                table: "LanguageModel",
                column: "GroupTypeId",
                principalTable: "LanguageGroupTypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LanguageModel_LanguageGroupTypeModel_GroupTypeId",
                table: "LanguageModel");

            migrationBuilder.DropTable(
                name: "LanguageGroupTypeModel");

            migrationBuilder.DropIndex(
                name: "IX_LanguageModel_GroupTypeId",
                table: "LanguageModel");

            migrationBuilder.DropColumn(
                name: "GroupTypeId",
                table: "LanguageModel");

            migrationBuilder.RenameColumn(
                name: "CustomModifier",
                table: "AttributeModel",
                newName: "CustomModifer");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "LanguageModel",
                nullable: false,
                defaultValue: 0);
        }
    }
}
