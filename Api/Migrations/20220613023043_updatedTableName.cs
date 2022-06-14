using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class updatedTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plastic_PropertyTypes_PlasticTypeId",
                table: "Plastic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyTypes",
                table: "PropertyTypes");

            migrationBuilder.DropColumn(
                name: "PlasticId",
                table: "Plastic");

            migrationBuilder.DropColumn(
                name: "PlasticTypeId",
                table: "PropertyTypes");

            migrationBuilder.RenameTable(
                name: "PropertyTypes",
                newName: "PlasticTypes");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Plastic",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlasticTypes",
                table: "PlasticTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plastic_PlasticTypes_PlasticTypeId",
                table: "Plastic",
                column: "PlasticTypeId",
                principalTable: "PlasticTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plastic_PlasticTypes_PlasticTypeId",
                table: "Plastic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlasticTypes",
                table: "PlasticTypes");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Plastic");

            migrationBuilder.RenameTable(
                name: "PlasticTypes",
                newName: "PropertyTypes");

            migrationBuilder.AddColumn<int>(
                name: "PlasticId",
                table: "Plastic",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlasticTypeId",
                table: "PropertyTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyTypes",
                table: "PropertyTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plastic_PropertyTypes_PlasticTypeId",
                table: "Plastic",
                column: "PlasticTypeId",
                principalTable: "PropertyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
