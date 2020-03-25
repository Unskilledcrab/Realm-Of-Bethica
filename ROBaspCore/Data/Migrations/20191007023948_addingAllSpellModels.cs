using Microsoft.EntityFrameworkCore.Migrations;

namespace ROBaspCore.Data.Migrations
{
    public partial class addingAllSpellModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArcaneSphereModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ArcaneValue = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArcaneSphereModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpellAreaModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ArcaneValue = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellAreaModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpellCastingTimeModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ArcaneValue = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellCastingTimeModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpellDurationModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ArcaneValue = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellDurationModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpellRangeModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ArcaneValue = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellRangeModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpellSaveModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ArcaneValue = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellSaveModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpellSizeLimitModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ArcaneValue = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellSizeLimitModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpellModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SpellLevel = table.Column<int>(nullable: false),
                    ArcaneSphereId = table.Column<int>(nullable: true),
                    RangeId = table.Column<int>(nullable: true),
                    AreaId = table.Column<int>(nullable: true),
                    SizeLimitId = table.Column<int>(nullable: true),
                    DurationId = table.Column<int>(nullable: true),
                    SaveId = table.Column<int>(nullable: true),
                    CastingTimeId = table.Column<int>(nullable: true),
                    Damage = table.Column<int>(nullable: false),
                    Armor = table.Column<int>(nullable: false),
                    Movement = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellModel_ArcaneSphereModel_ArcaneSphereId",
                        column: x => x.ArcaneSphereId,
                        principalTable: "ArcaneSphereModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpellModel_SpellAreaModel_AreaId",
                        column: x => x.AreaId,
                        principalTable: "SpellAreaModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpellModel_SpellCastingTimeModel_CastingTimeId",
                        column: x => x.CastingTimeId,
                        principalTable: "SpellCastingTimeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpellModel_SpellDurationModel_DurationId",
                        column: x => x.DurationId,
                        principalTable: "SpellDurationModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpellModel_SpellRangeModel_RangeId",
                        column: x => x.RangeId,
                        principalTable: "SpellRangeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpellModel_SpellSaveModel_SaveId",
                        column: x => x.SaveId,
                        principalTable: "SpellSaveModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpellModel_SpellSizeLimitModel_SizeLimitId",
                        column: x => x.SizeLimitId,
                        principalTable: "SpellSizeLimitModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSheet_Spell_Link",
                columns: table => new
                {
                    CharacterSheetId = table.Column<int>(nullable: false),
                    SpellId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheet_Spell_Link", x => new { x.CharacterSheetId, x.SpellId });
                    table.ForeignKey(
                        name: "FK_CharacterSheet_Spell_Link_CharacterSheetModel_CharacterSheetId",
                        column: x => x.CharacterSheetId,
                        principalTable: "CharacterSheetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSheet_Spell_Link_SpellModel_SpellId",
                        column: x => x.SpellId,
                        principalTable: "SpellModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheet_Spell_Link_SpellId",
                table: "CharacterSheet_Spell_Link",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellModel_ArcaneSphereId",
                table: "SpellModel",
                column: "ArcaneSphereId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellModel_AreaId",
                table: "SpellModel",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellModel_CastingTimeId",
                table: "SpellModel",
                column: "CastingTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellModel_DurationId",
                table: "SpellModel",
                column: "DurationId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellModel_RangeId",
                table: "SpellModel",
                column: "RangeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellModel_SaveId",
                table: "SpellModel",
                column: "SaveId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellModel_SizeLimitId",
                table: "SpellModel",
                column: "SizeLimitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterSheet_Spell_Link");

            migrationBuilder.DropTable(
                name: "SpellModel");

            migrationBuilder.DropTable(
                name: "ArcaneSphereModel");

            migrationBuilder.DropTable(
                name: "SpellAreaModel");

            migrationBuilder.DropTable(
                name: "SpellCastingTimeModel");

            migrationBuilder.DropTable(
                name: "SpellDurationModel");

            migrationBuilder.DropTable(
                name: "SpellRangeModel");

            migrationBuilder.DropTable(
                name: "SpellSaveModel");

            migrationBuilder.DropTable(
                name: "SpellSizeLimitModel");
        }
    }
}
