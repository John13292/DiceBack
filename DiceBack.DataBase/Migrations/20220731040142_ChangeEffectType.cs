using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiceBack.DataBase.Migrations
{
    public partial class ChangeEffectType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNegative",
                table: "Effects");

            migrationBuilder.DropColumn(
                name: "IsPositive",
                table: "Effects");

            migrationBuilder.AddColumn<int>(
                name: "EffectType",
                table: "Effects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EffectType",
                table: "Effects");

            migrationBuilder.AddColumn<bool>(
                name: "IsNegative",
                table: "Effects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPositive",
                table: "Effects",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
