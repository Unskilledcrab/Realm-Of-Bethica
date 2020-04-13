using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ROB.Web.Data.Migrations
{
    public partial class addingWeaponModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeaponModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WeaponTypeId = table.Column<int>(nullable: true),
                    SizeId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Handed = table.Column<int>(nullable: false),
                    RateOfAttack = table.Column<int>(nullable: false),
                    DamageValue = table.Column<int>(nullable: false),
                    DamageFactor = table.Column<double>(nullable: false),
                    DamageTypeId = table.Column<int>(nullable: true),
                    ReactionModifier = table.Column<int>(nullable: false),
                    PenetrationValue = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Range = table.Column<int>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    Evasion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeaponModel_DamageTypeModel_DamageTypeId",
                        column: x => x.DamageTypeId,
                        principalTable: "DamageTypeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeaponModel_WeaponSizeModel_SizeId",
                        column: x => x.SizeId,
                        principalTable: "WeaponSizeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeaponModel_WeaponTypeModel_WeaponTypeId",
                        column: x => x.WeaponTypeId,
                        principalTable: "WeaponTypeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeaponModel_DamageTypeId",
                table: "WeaponModel",
                column: "DamageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponModel_SizeId",
                table: "WeaponModel",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponModel_WeaponTypeId",
                table: "WeaponModel",
                column: "WeaponTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeaponModel");
        }
    }
}
