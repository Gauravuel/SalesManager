using Microsoft.EntityFrameworkCore.Migrations;

namespace MyManager.Server.Data.Migrations
{
    public partial class customercredittablemigrated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerCredits",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Customer_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sum_Total = table.Column<int>(type: "int", nullable: false),
                    Paid_Amount = table.Column<int>(type: "int", nullable: false),
                    Purchase_Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Purchase_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Credited_amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCredits", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerCredits");
        }
    }
}
