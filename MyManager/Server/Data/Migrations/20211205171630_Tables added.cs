using Microsoft.EntityFrameworkCore.Migrations;

namespace MyManager.Server.Data.Migrations
{
    public partial class Tablesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.CreateTable(
                name: "Charger",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Watt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Port = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Fast_Charging = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Charger_Brand_Brand_Id",
                        column: x => x.Brand_Id,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Headphone",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headphone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Headphone_Brand_Brand_Id",
                        column: x => x.Brand_Id,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneCase",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Compatibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transparent = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneCase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneCase_Brand_Brand_Id",
                        column: x => x.Brand_Id,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Smartphones",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Storage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Cpu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smartphones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Smartphones_Brand_Brand_Id",
                        column: x => x.Brand_Id,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Charger_Brand_Id",
                table: "Charger",
                column: "Brand_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Headphone_Brand_Id",
                table: "Headphone",
                column: "Brand_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCase_Brand_Id",
                table: "PhoneCase",
                column: "Brand_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Smartphones_Brand_Id",
                table: "Smartphones",
                column: "Brand_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Charger");

            migrationBuilder.DropTable(
                name: "Headphone");

            migrationBuilder.DropTable(
                name: "PhoneCase");

            migrationBuilder.DropTable(
                name: "Smartphones");

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Bill_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });
        }
    }
}
