using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class addmigrationupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Plastic");

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "Plastic",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Plastic");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Plastic",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
