using Microsoft.EntityFrameworkCore.Migrations;

namespace ROB.Web.Data.Migrations
{
    public partial class fixingRecentModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoisonModel_PoisonClassModel_ClassId",
                table: "PoisonModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PoisonModel_PoisonTypeModel_TypeId",
                table: "PoisonModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellModel_ArcaneSphereModel_ArcaneSphereId",
                table: "SpellModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellModel_SpellAreaModel_AreaId",
                table: "SpellModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellModel_SpellCastingTimeModel_CastingTimeId",
                table: "SpellModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellModel_SpellDurationModel_DurationId",
                table: "SpellModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellModel_SpellRangeModel_RangeId",
                table: "SpellModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellModel_SpellSaveModel_SaveId",
                table: "SpellModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellModel_SpellSizeLimitModel_SizeLimitId",
                table: "SpellModel");

            migrationBuilder.DropForeignKey(
                name: "FK_WeaponModel_DamageTypeModel_DamageTypeId",
                table: "WeaponModel");

            migrationBuilder.DropForeignKey(
                name: "FK_WeaponModel_WeaponSizeModel_SizeId",
                table: "WeaponModel");

            migrationBuilder.DropForeignKey(
                name: "FK_WeaponModel_WeaponTypeModel_WeaponTypeId",
                table: "WeaponModel");

            migrationBuilder.AlterColumn<int>(
                name: "WeaponTypeId",
                table: "WeaponModel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SizeId",
                table: "WeaponModel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DamageTypeId",
                table: "WeaponModel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SizeLimitId",
                table: "SpellModel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SaveId",
                table: "SpellModel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RangeId",
                table: "SpellModel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DurationId",
                table: "SpellModel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CastingTimeId",
                table: "SpellModel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "SpellModel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArcaneSphereId",
                table: "SpellModel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "PoisonModel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "PoisonModel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonModel_PoisonClassModel_ClassId",
                table: "PoisonModel",
                column: "ClassId",
                principalTable: "PoisonClassModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonModel_PoisonTypeModel_TypeId",
                table: "PoisonModel",
                column: "TypeId",
                principalTable: "PoisonTypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellModel_ArcaneSphereModel_ArcaneSphereId",
                table: "SpellModel",
                column: "ArcaneSphereId",
                principalTable: "ArcaneSphereModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellModel_SpellAreaModel_AreaId",
                table: "SpellModel",
                column: "AreaId",
                principalTable: "SpellAreaModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellModel_SpellCastingTimeModel_CastingTimeId",
                table: "SpellModel",
                column: "CastingTimeId",
                principalTable: "SpellCastingTimeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellModel_SpellDurationModel_DurationId",
                table: "SpellModel",
                column: "DurationId",
                principalTable: "SpellDurationModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellModel_SpellRangeModel_RangeId",
                table: "SpellModel",
                column: "RangeId",
                principalTable: "SpellRangeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellModel_SpellSaveModel_SaveId",
                table: "SpellModel",
                column: "SaveId",
                principalTable: "SpellSaveModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellModel_SpellSizeLimitModel_SizeLimitId",
                table: "SpellModel",
                column: "SizeLimitId",
                principalTable: "SpellSizeLimitModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeaponModel_DamageTypeModel_DamageTypeId",
                table: "WeaponModel",
                column: "DamageTypeId",
                principalTable: "DamageTypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeaponModel_WeaponSizeModel_SizeId",
                table: "WeaponModel",
                column: "SizeId",
                principalTable: "WeaponSizeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeaponModel_WeaponTypeModel_WeaponTypeId",
                table: "WeaponModel",
                column: "WeaponTypeId",
                principalTable: "WeaponTypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoisonModel_PoisonClassModel_ClassId",
                table: "PoisonModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PoisonModel_PoisonTypeModel_TypeId",
                table: "PoisonModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellModel_ArcaneSphereModel_ArcaneSphereId",
                table: "SpellModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellModel_SpellAreaModel_AreaId",
                table: "SpellModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellModel_SpellCastingTimeModel_CastingTimeId",
                table: "SpellModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellModel_SpellDurationModel_DurationId",
                table: "SpellModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellModel_SpellRangeModel_RangeId",
                table: "SpellModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellModel_SpellSaveModel_SaveId",
                table: "SpellModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellModel_SpellSizeLimitModel_SizeLimitId",
                table: "SpellModel");

            migrationBuilder.DropForeignKey(
                name: "FK_WeaponModel_DamageTypeModel_DamageTypeId",
                table: "WeaponModel");

            migrationBuilder.DropForeignKey(
                name: "FK_WeaponModel_WeaponSizeModel_SizeId",
                table: "WeaponModel");

            migrationBuilder.DropForeignKey(
                name: "FK_WeaponModel_WeaponTypeModel_WeaponTypeId",
                table: "WeaponModel");

            migrationBuilder.AlterColumn<int>(
                name: "WeaponTypeId",
                table: "WeaponModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SizeId",
                table: "WeaponModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DamageTypeId",
                table: "WeaponModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SizeLimitId",
                table: "SpellModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SaveId",
                table: "SpellModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RangeId",
                table: "SpellModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DurationId",
                table: "SpellModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CastingTimeId",
                table: "SpellModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "SpellModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ArcaneSphereId",
                table: "SpellModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "PoisonModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "PoisonModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonModel_PoisonClassModel_ClassId",
                table: "PoisonModel",
                column: "ClassId",
                principalTable: "PoisonClassModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PoisonModel_PoisonTypeModel_TypeId",
                table: "PoisonModel",
                column: "TypeId",
                principalTable: "PoisonTypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellModel_ArcaneSphereModel_ArcaneSphereId",
                table: "SpellModel",
                column: "ArcaneSphereId",
                principalTable: "ArcaneSphereModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellModel_SpellAreaModel_AreaId",
                table: "SpellModel",
                column: "AreaId",
                principalTable: "SpellAreaModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellModel_SpellCastingTimeModel_CastingTimeId",
                table: "SpellModel",
                column: "CastingTimeId",
                principalTable: "SpellCastingTimeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellModel_SpellDurationModel_DurationId",
                table: "SpellModel",
                column: "DurationId",
                principalTable: "SpellDurationModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellModel_SpellRangeModel_RangeId",
                table: "SpellModel",
                column: "RangeId",
                principalTable: "SpellRangeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellModel_SpellSaveModel_SaveId",
                table: "SpellModel",
                column: "SaveId",
                principalTable: "SpellSaveModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellModel_SpellSizeLimitModel_SizeLimitId",
                table: "SpellModel",
                column: "SizeLimitId",
                principalTable: "SpellSizeLimitModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeaponModel_DamageTypeModel_DamageTypeId",
                table: "WeaponModel",
                column: "DamageTypeId",
                principalTable: "DamageTypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeaponModel_WeaponSizeModel_SizeId",
                table: "WeaponModel",
                column: "SizeId",
                principalTable: "WeaponSizeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeaponModel_WeaponTypeModel_WeaponTypeId",
                table: "WeaponModel",
                column: "WeaponTypeId",
                principalTable: "WeaponTypeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
