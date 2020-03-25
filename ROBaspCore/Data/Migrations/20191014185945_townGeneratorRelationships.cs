using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ROBaspCore.Data.Migrations
{
    public partial class townGeneratorRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AreAttributesPublic",
                table: "CharacterSheetModel",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "CharacterSheetModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "CharacterSheetModel",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "CharacterSheetModel",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "CharacterSheetModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "BuildingRatingModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingRatingModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionViewer_CharacterSheet_Link",
                columns: table => new
                {
                    CharacterSheetId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionViewer_CharacterSheet_Link", x => new { x.CharacterSheetId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_PermissionViewer_CharacterSheet_Link_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionViewer_CharacterSheet_Link_CharacterSheetModel_CharacterSheetId",
                        column: x => x.CharacterSheetId,
                        principalTable: "CharacterSheetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestGroupModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Synopsis = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestGroupModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestGroupModel_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestRatingModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<string>(nullable: true),
                    SuggestedLevel = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestRatingModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestTagModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Color = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestTagModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorldModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PicturePath = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorldModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorldModel_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuildingModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: true),
                    BuildingOwnerId = table.Column<int>(nullable: true),
                    BuildingRatingId = table.Column<int>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    PicturePath = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingModel_CharacterSheetModel_BuildingOwnerId",
                        column: x => x.BuildingOwnerId,
                        principalTable: "CharacterSheetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuildingModel_BuildingRatingModel_BuildingRatingId",
                        column: x => x.BuildingRatingId,
                        principalTable: "BuildingRatingModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingModel_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSheet_QuestGroup_Link",
                columns: table => new
                {
                    QuestGroupId = table.Column<int>(nullable: false),
                    CharacterSheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheet_QuestGroup_Link", x => new { x.CharacterSheetId, x.QuestGroupId });
                    table.ForeignKey(
                        name: "FK_CharacterSheet_QuestGroup_Link_CharacterSheetModel_CharacterSheetId",
                        column: x => x.CharacterSheetId,
                        principalTable: "CharacterSheetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSheet_QuestGroup_Link_QuestGroupModel_QuestGroupId",
                        column: x => x.QuestGroupId,
                        principalTable: "QuestGroupModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionViewer_QuestGroup_Link",
                columns: table => new
                {
                    QuestGroupId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionViewer_QuestGroup_Link", x => new { x.QuestGroupId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_PermissionViewer_QuestGroup_Link_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionViewer_QuestGroup_Link_QuestGroupModel_QuestGroupId",
                        column: x => x.QuestGroupId,
                        principalTable: "QuestGroupModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Synopsis = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    DifficultyRatingId = table.Column<int>(nullable: false),
                    QuestGroupId = table.Column<int>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestModel_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestModel_QuestRatingModel_DifficultyRatingId",
                        column: x => x.DifficultyRatingId,
                        principalTable: "QuestRatingModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestModel_QuestGroupModel_QuestGroupId",
                        column: x => x.QuestGroupId,
                        principalTable: "QuestGroupModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionViewer_World_Link",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    WorldId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionViewer_World_Link", x => new { x.WorldId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_PermissionViewer_World_Link_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionViewer_World_Link_WorldModel_WorldId",
                        column: x => x.WorldId,
                        principalTable: "WorldModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TownModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PicturePath = table.Column<string>(nullable: true),
                    WorldId = table.Column<int>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TownModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TownModel_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TownModel_WorldModel_WorldId",
                        column: x => x.WorldId,
                        principalTable: "WorldModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Building_Armor_Link",
                columns: table => new
                {
                    BuildingId = table.Column<int>(nullable: false),
                    ArmorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building_Armor_Link", x => new { x.BuildingId, x.ArmorId });
                    table.ForeignKey(
                        name: "FK_Building_Armor_Link_ArmorModel_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "ArmorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Building_Armor_Link_BuildingModel_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "BuildingModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Building_Item_Link",
                columns: table => new
                {
                    BuildingId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building_Item_Link", x => new { x.BuildingId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_Building_Item_Link_BuildingModel_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "BuildingModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Building_Item_Link_ItemModel_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ItemModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Building_Poison_Link",
                columns: table => new
                {
                    BuildingId = table.Column<int>(nullable: false),
                    PoisonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building_Poison_Link", x => new { x.BuildingId, x.PoisonId });
                    table.ForeignKey(
                        name: "FK_Building_Poison_Link_BuildingModel_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "BuildingModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Building_Poison_Link_PoisonModel_PoisonId",
                        column: x => x.PoisonId,
                        principalTable: "PoisonModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Building_Shield_Link",
                columns: table => new
                {
                    BuildingId = table.Column<int>(nullable: false),
                    ShieldId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building_Shield_Link", x => new { x.BuildingId, x.ShieldId });
                    table.ForeignKey(
                        name: "FK_Building_Shield_Link_BuildingModel_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "BuildingModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Building_Shield_Link_ShieldModel_ShieldId",
                        column: x => x.ShieldId,
                        principalTable: "ShieldModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Building_Weapon_Link",
                columns: table => new
                {
                    BuildingId = table.Column<int>(nullable: false),
                    WeaponId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building_Weapon_Link", x => new { x.BuildingId, x.WeaponId });
                    table.ForeignKey(
                        name: "FK_Building_Weapon_Link_BuildingModel_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "BuildingModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Building_Weapon_Link_WeaponModel_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "WeaponModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionViewer_Building_Link",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    BuildingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionViewer_Building_Link", x => new { x.BuildingId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_PermissionViewer_Building_Link_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionViewer_Building_Link_BuildingModel_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "BuildingModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSheet_Quest_Link",
                columns: table => new
                {
                    CharacterSheetId = table.Column<int>(nullable: false),
                    QuestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheet_Quest_Link", x => new { x.CharacterSheetId, x.QuestId });
                    table.ForeignKey(
                        name: "FK_CharacterSheet_Quest_Link_CharacterSheetModel_CharacterSheetId",
                        column: x => x.CharacterSheetId,
                        principalTable: "CharacterSheetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSheet_Quest_Link_QuestModel_QuestId",
                        column: x => x.QuestId,
                        principalTable: "QuestModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionViewer_Quest_Link",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    QuestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionViewer_Quest_Link", x => new { x.QuestId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_PermissionViewer_Quest_Link_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionViewer_Quest_Link_QuestModel_QuestId",
                        column: x => x.QuestId,
                        principalTable: "QuestModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quest_QuestTag_Link",
                columns: table => new
                {
                    QuestTagId = table.Column<int>(nullable: false),
                    QuestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quest_QuestTag_Link", x => new { x.QuestId, x.QuestTagId });
                    table.ForeignKey(
                        name: "FK_Quest_QuestTag_Link_QuestModel_QuestId",
                        column: x => x.QuestId,
                        principalTable: "QuestModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quest_QuestTag_Link_QuestTagModel_QuestTagId",
                        column: x => x.QuestTagId,
                        principalTable: "QuestTagModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionViewer_Town_Link",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    TownId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionViewer_Town_Link", x => new { x.TownId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_PermissionViewer_Town_Link_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionViewer_Town_Link_TownModel_TownId",
                        column: x => x.TownId,
                        principalTable: "TownModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Town_Building_Link",
                columns: table => new
                {
                    BuildingId = table.Column<int>(nullable: false),
                    TownId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Town_Building_Link", x => new { x.TownId, x.BuildingId });
                    table.ForeignKey(
                        name: "FK_Town_Building_Link_BuildingModel_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "BuildingModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Town_Building_Link_TownModel_TownId",
                        column: x => x.TownId,
                        principalTable: "TownModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Town_NPC_Link",
                columns: table => new
                {
                    CharacterSheetId = table.Column<int>(nullable: false),
                    TownId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Town_NPC_Link", x => new { x.CharacterSheetId, x.TownId });
                    table.ForeignKey(
                        name: "FK_Town_NPC_Link_CharacterSheetModel_CharacterSheetId",
                        column: x => x.CharacterSheetId,
                        principalTable: "CharacterSheetModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Town_NPC_Link_TownModel_TownId",
                        column: x => x.TownId,
                        principalTable: "TownModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheetModel_CreatorId",
                table: "CharacterSheetModel",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Building_Armor_Link_ArmorId",
                table: "Building_Armor_Link",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Building_Item_Link_ItemId",
                table: "Building_Item_Link",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Building_Poison_Link_PoisonId",
                table: "Building_Poison_Link",
                column: "PoisonId");

            migrationBuilder.CreateIndex(
                name: "IX_Building_Shield_Link_ShieldId",
                table: "Building_Shield_Link",
                column: "ShieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Building_Weapon_Link_WeaponId",
                table: "Building_Weapon_Link",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingModel_BuildingOwnerId",
                table: "BuildingModel",
                column: "BuildingOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingModel_BuildingRatingId",
                table: "BuildingModel",
                column: "BuildingRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingModel_CreatorId",
                table: "BuildingModel",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheet_Quest_Link_QuestId",
                table: "CharacterSheet_Quest_Link",
                column: "QuestId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheet_QuestGroup_Link_QuestGroupId",
                table: "CharacterSheet_QuestGroup_Link",
                column: "QuestGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionViewer_Building_Link_ApplicationUserId",
                table: "PermissionViewer_Building_Link",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionViewer_CharacterSheet_Link_ApplicationUserId",
                table: "PermissionViewer_CharacterSheet_Link",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionViewer_Quest_Link_ApplicationUserId",
                table: "PermissionViewer_Quest_Link",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionViewer_QuestGroup_Link_ApplicationUserId",
                table: "PermissionViewer_QuestGroup_Link",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionViewer_Town_Link_ApplicationUserId",
                table: "PermissionViewer_Town_Link",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionViewer_World_Link_ApplicationUserId",
                table: "PermissionViewer_World_Link",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Quest_QuestTag_Link_QuestTagId",
                table: "Quest_QuestTag_Link",
                column: "QuestTagId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestGroupModel_CreatorId",
                table: "QuestGroupModel",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestModel_CreatorId",
                table: "QuestModel",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestModel_DifficultyRatingId",
                table: "QuestModel",
                column: "DifficultyRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestModel_QuestGroupId",
                table: "QuestModel",
                column: "QuestGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Town_Building_Link_BuildingId",
                table: "Town_Building_Link",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Town_NPC_Link_TownId",
                table: "Town_NPC_Link",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_TownModel_CreatorId",
                table: "TownModel",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TownModel_WorldId",
                table: "TownModel",
                column: "WorldId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldModel_CreatorId",
                table: "WorldModel",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSheetModel_AspNetUsers_CreatorId",
                table: "CharacterSheetModel",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSheetModel_AspNetUsers_CreatorId",
                table: "CharacterSheetModel");

            migrationBuilder.DropTable(
                name: "Building_Armor_Link");

            migrationBuilder.DropTable(
                name: "Building_Item_Link");

            migrationBuilder.DropTable(
                name: "Building_Poison_Link");

            migrationBuilder.DropTable(
                name: "Building_Shield_Link");

            migrationBuilder.DropTable(
                name: "Building_Weapon_Link");

            migrationBuilder.DropTable(
                name: "CharacterSheet_Quest_Link");

            migrationBuilder.DropTable(
                name: "CharacterSheet_QuestGroup_Link");

            migrationBuilder.DropTable(
                name: "PermissionViewer_Building_Link");

            migrationBuilder.DropTable(
                name: "PermissionViewer_CharacterSheet_Link");

            migrationBuilder.DropTable(
                name: "PermissionViewer_Quest_Link");

            migrationBuilder.DropTable(
                name: "PermissionViewer_QuestGroup_Link");

            migrationBuilder.DropTable(
                name: "PermissionViewer_Town_Link");

            migrationBuilder.DropTable(
                name: "PermissionViewer_World_Link");

            migrationBuilder.DropTable(
                name: "Quest_QuestTag_Link");

            migrationBuilder.DropTable(
                name: "Town_Building_Link");

            migrationBuilder.DropTable(
                name: "Town_NPC_Link");

            migrationBuilder.DropTable(
                name: "QuestModel");

            migrationBuilder.DropTable(
                name: "QuestTagModel");

            migrationBuilder.DropTable(
                name: "BuildingModel");

            migrationBuilder.DropTable(
                name: "TownModel");

            migrationBuilder.DropTable(
                name: "QuestRatingModel");

            migrationBuilder.DropTable(
                name: "QuestGroupModel");

            migrationBuilder.DropTable(
                name: "BuildingRatingModel");

            migrationBuilder.DropTable(
                name: "WorldModel");

            migrationBuilder.DropIndex(
                name: "IX_CharacterSheetModel_CreatorId",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "AreAttributesPublic",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "CharacterSheetModel");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "CharacterSheetModel");
        }
    }
}
