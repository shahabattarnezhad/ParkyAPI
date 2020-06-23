using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkyAPI.Migrations
{
    public partial class SecondTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NationalParks",
                table: "NationalParks");

            migrationBuilder.RenameTable(
                name: "NationalParks",
                newName: "Tbl_NationalPark");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_NationalPark",
                table: "Tbl_NationalPark",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_NationalPark",
                table: "Tbl_NationalPark");

            migrationBuilder.RenameTable(
                name: "Tbl_NationalPark",
                newName: "NationalParks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NationalParks",
                table: "NationalParks",
                column: "Id");
        }
    }
}
