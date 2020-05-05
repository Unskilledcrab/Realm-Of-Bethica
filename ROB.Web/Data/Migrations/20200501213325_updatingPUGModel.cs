using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ROB.Web.Data.Migrations
{
    public partial class updatingPUGModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventDate",
                table: "PUBConGameModel");

            migrationBuilder.AddColumn<string>(
                name: "EventStartTime",
                table: "PUBConGameModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventStartTime",
                table: "PUBConGameModel");

            migrationBuilder.AddColumn<DateTime>(
                name: "EventDate",
                table: "PUBConGameModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
