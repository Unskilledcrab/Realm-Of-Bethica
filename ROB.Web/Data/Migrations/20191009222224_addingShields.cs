using Microsoft.EntityFrameworkCore.Migrations;

namespace ROB.Web.Data.Migrations
{
    public partial class addingShields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemModel_ItemCategoryModel_CategoryId",
                table: "ItemModel");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ItemModel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SecondaryArcaneElementModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Tier = table.Column<int>(nullable: false),
                    ArcaneValue = table.Column<int>(nullable: false),
                    Prerequisite = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SpellModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondaryArcaneElementModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecondaryArcaneElementModel_SpellModel_SpellModelId",
                        column: x => x.SpellModelId,
                        principalTable: "SpellModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShieldModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DefenseRating = table.Column<int>(nullable: false),
                    PenetrationDefenseRating = table.Column<int>(nullable: false),
                    EvasionModifier = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Cost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShieldModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecondaryArcaneElementModel_SpellModelId",
                table: "SecondaryArcaneElementModel",
                column: "SpellModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModel_ItemCategoryModel_CategoryId",
                table: "ItemModel",
                column: "CategoryId",
                principalTable: "ItemCategoryModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemModel_ItemCategoryModel_CategoryId",
                table: "ItemModel");

            migrationBuilder.DropTable(
                name: "SecondaryArcaneElementModel");

            migrationBuilder.DropTable(
                name: "ShieldModel");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ItemModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModel_ItemCategoryModel_CategoryId",
                table: "ItemModel",
                column: "CategoryId",
                principalTable: "ItemCategoryModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
