using Microsoft.EntityFrameworkCore.Migrations;

namespace MyManager.Server.Data.Migrations
{
    public partial class Customerpurchasecreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerPurchases",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Customer_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Purchase_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Purchase_Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sum_Total = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPurchases", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerPurchases");
        }
    }
}
