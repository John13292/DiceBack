using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiceBack.Migrations
{
    public partial class AddUpdateStamptoeffectcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateStamp",
                table: "Effects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateStamp",
                table: "Effects");
        }
    }
}
