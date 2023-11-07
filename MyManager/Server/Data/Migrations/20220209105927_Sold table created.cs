using Microsoft.EntityFrameworkCore.Migrations;

namespace MyManager.Server.Data.Migrations
{
    public partial class Soldtablecreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Puschase_Date",
                table: "Sold",
                newName: "Purchase_Id");

            migrationBuilder.AddColumn<string>(
                name: "Purchase_Date",
                table: "Sold",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Purchase_Date",
                table: "Sold");

            migrationBuilder.RenameColumn(
                name: "Purchase_Id",
                table: "Sold",
                newName: "Puschase_Date");
        }
    }
}
