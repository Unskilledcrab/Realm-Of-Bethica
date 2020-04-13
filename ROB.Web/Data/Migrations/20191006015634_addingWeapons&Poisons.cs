using Microsoft.EntityFrameworkCore.Migrations;

namespace ROB.Web.Data.Migrations
{
    public partial class addingWeaponsPoisons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemCategoryModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategoryModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoisonClassModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoisonClassModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoisonTypeModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoisonTypeModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    ResellValue = table.Column<double>(nullable: false),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemModel_ItemCategoryModel_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ItemCategoryModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PoisonModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Effect = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    ConstitutionDamage = table.Column<int>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    ClassId = table.Column<int>(nullable: true),
                    TypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoisonModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoisonModel_PoisonClassModel_ClassId",
                        column: x => x.ClassId,
                        principalTable: "PoisonClassModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoisonModel_PoisonTypeModel_TypeId",
                        column: x => x.TypeId,
                        principalTable: "PoisonTypeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSheet_Item_Link",
                columns: table => new
                {
                    CharacterSheetId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheet_Item_Link", x => new { x.CharacterSheetId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_CharacterSheet_Item_Link_CharacterSheetModel_CharacterSheetId",
                        column: x => x.CharacterSheetId,
                        principalTable: "CharacterSheetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSheet_Item_Link_ItemModel_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ItemModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSheet_Poison_Link",
                columns: table => new
                {
                    CharacterSheetId = table.Column<int>(nullable: false),
                    PoisonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheet_Poison_Link", x => new { x.CharacterSheetId, x.PoisonId });
                    table.ForeignKey(
                        name: "FK_CharacterSheet_Poison_Link_CharacterSheetModel_CharacterSheetId",
                        column: x => x.CharacterSheetId,
                        principalTable: "CharacterSheetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSheet_Poison_Link_PoisonModel_PoisonId",
                        column: x => x.PoisonId,
                        principalTable: "PoisonModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheet_Item_Link_ItemId",
                table: "CharacterSheet_Item_Link",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheet_Poison_Link_PoisonId",
                table: "CharacterSheet_Poison_Link",
                column: "PoisonId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemModel_CategoryId",
                table: "ItemModel",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PoisonModel_ClassId",
                table: "PoisonModel",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_PoisonModel_TypeId",
                table: "PoisonModel",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterSheet_Item_Link");

            migrationBuilder.DropTable(
                name: "CharacterSheet_Poison_Link");

            migrationBuilder.DropTable(
                name: "ItemModel");

            migrationBuilder.DropTable(
                name: "PoisonModel");

            migrationBuilder.DropTable(
                name: "ItemCategoryModel");

            migrationBuilder.DropTable(
                name: "PoisonClassModel");

            migrationBuilder.DropTable(
                name: "PoisonTypeModel");
        }
    }
}
