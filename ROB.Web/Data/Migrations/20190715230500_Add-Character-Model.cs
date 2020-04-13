using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ROB.Web.Data.Migrations
{
    public partial class AddCharacterModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RaceModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DescriptionBrief = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Walk = table.Column<int>(nullable: false),
                    Tactical = table.Column<int>(nullable: false),
                    Sprint = table.Column<int>(nullable: false),
                    Luck = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttributeModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeType = table.Column<int>(nullable: false),
                    BaseModifier = table.Column<int>(nullable: false),
                    CustomModifer = table.Column<int>(nullable: false),
                    RaceModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeModel_RaceModel_RaceModelId",
                        column: x => x.RaceModelId,
                        principalTable: "RaceModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    RaceId = table.Column<int>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterModel_RaceModel_RaceId",
                        column: x => x.RaceId,
                        principalTable: "RaceModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeModel_RaceModelId",
                table: "AttributeModel",
                column: "RaceModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterModel_RaceId",
                table: "CharacterModel",
                column: "RaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeModel");

            migrationBuilder.DropTable(
                name: "CharacterModel");

            migrationBuilder.DropTable(
                name: "RaceModel");
        }
    }
}
