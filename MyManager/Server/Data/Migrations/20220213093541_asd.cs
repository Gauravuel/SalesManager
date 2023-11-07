using Microsoft.EntityFrameworkCore.Migrations;

namespace MyManager.Server.Data.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total_Price",
                table: "Sold",
                newName: "TotalPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Sold",
                newName: "Total_Price");
        }
    }
}
