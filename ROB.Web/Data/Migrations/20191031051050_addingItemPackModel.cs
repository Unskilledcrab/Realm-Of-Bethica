using Microsoft.EntityFrameworkCore.Migrations;

namespace ROB.Web.Data.Migrations
{
    public partial class addingItemPackModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecondaryArcaneElementModel");

            migrationBuilder.DropColumn(
                name: "ArcaneValue",
                table: "ArcaneSphereModel");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "DamageTypeModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Faith",
                table: "CharacterSheetModel",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ArcaneSphereModel",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ArcanePowerAttributeModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Tier = table.Column<int>(nullable: false),
                    ArcaneValue = table.Column<int>(nullable: false),
                    DamageTypeId = table.Column<int>(nullable: true),
                    Effects = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArcanePowerAttributeModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArcanePowerAttributeModel_DamageTypeModel_DamageTypeId",
                        column: x => x.DamageTypeId,
                        principalTable: "DamageTypeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArcaneSubgroupModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ArcaneValue = table.Column<int>(nullable: false),
                    ArcaneSphereId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArcaneSubgroupModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArcaneSubgroupModel_ArcaneSphereModel_ArcaneSphereId",
                        column: x => x.ArcaneSphereId,
                        principalTable: "ArcaneSphereModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemPackModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPackModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spell_ArcanePowerAttribute_Link",
                columns: table => new
                {
                    SpellId = table.Column<int>(nullable: false),
                    ArcanePowerAttributeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spell_ArcanePowerAttribute_Link", x => new { x.SpellId, x.ArcanePowerAttributeId });
                    table.ForeignKey(
                        name: "FK_Spell_ArcanePowerAttribute_Link_ArcanePowerAttributeModel_ArcanePowerAttributeId",
                        column: x => x.ArcanePowerAttributeId,
                        principalTable: "ArcanePowerAttributeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Spell_ArcanePowerAttribute_Link_SpellModel_SpellId",
                        column: x => x.SpellId,
                        principalTable: "SpellModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArcaneSubgroup_ArcanePowerAttribute_Link",
                columns: table => new
                {
                    ArcaneSubgroupId = table.Column<int>(nullable: false),
                    ArcanePowerAttributeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArcaneSubgroup_ArcanePowerAttribute_Link", x => new { x.ArcaneSubgroupId, x.ArcanePowerAttributeId });
                    table.ForeignKey(
                        name: "FK_ArcaneSubgroup_ArcanePowerAttribute_Link_ArcanePowerAttributeModel_ArcanePowerAttributeId",
                        column: x => x.ArcanePowerAttributeId,
                        principalTable: "ArcanePowerAttributeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArcaneSubgroup_ArcanePowerAttribute_Link_ArcaneSubgroupModel_ArcaneSubgroupId",
                        column: x => x.ArcaneSubgroupId,
                        principalTable: "ArcaneSubgroupModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemPack_Item_Link",
                columns: table => new
                {
                    ItemPackId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPack_Item_Link", x => new { x.ItemPackId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_ItemPack_Item_Link_ItemModel_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ItemModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPack_Item_Link_ItemPackModel_ItemPackId",
                        column: x => x.ItemPackId,
                        principalTable: "ItemPackModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArcanePowerAttributeModel_DamageTypeId",
                table: "ArcanePowerAttributeModel",
                column: "DamageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ArcaneSubgroup_ArcanePowerAttribute_Link_ArcanePowerAttributeId",
                table: "ArcaneSubgroup_ArcanePowerAttribute_Link",
                column: "ArcanePowerAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ArcaneSubgroupModel_ArcaneSphereId",
                table: "ArcaneSubgroupModel",
                column: "ArcaneSphereId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPack_Item_Link_ItemId",
                table: "ItemPack_Item_Link",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Spell_ArcanePowerAttribute_Link_ArcanePowerAttributeId",
                table: "Spell_ArcanePowerAttribute_Link",
                column: "ArcanePowerAttributeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArcaneSubgroup_ArcanePowerAttribute_Link");

            migrationBuilder.DropTable(
                name: "ItemPack_Item_Link");

            migrationBuilder.DropTable(
                name: "Spell_ArcanePowerAttribute_Link");

            migrationBuilder.DropTable(
                name: "ArcaneSubgroupModel");

            migrationBuilder.DropTable(
                name: "ItemPackModel");

            migrationBuilder.DropTable(
                name: "ArcanePowerAttributeModel");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "DamageTypeModel");

            migrationBuilder.AlterColumn<string>(
                name: "Faith",
                table: "CharacterSheetModel",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ArcaneSphereModel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArcaneValue",
                table: "ArcaneSphereModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SecondaryArcaneElementModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArcaneValue = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prerequisite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpellModelId = table.Column<int>(type: "int", nullable: true),
                    Tier = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_SecondaryArcaneElementModel_SpellModelId",
                table: "SecondaryArcaneElementModel",
                column: "SpellModelId");
        }
    }
}
