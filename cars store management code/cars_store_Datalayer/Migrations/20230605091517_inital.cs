using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cars_store_Datalayer.Migrations
{
    /// <inheritdoc />
    public partial class inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tabel_cars",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KM = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabel_cars", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tabel_Costomer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabel_Costomer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tabel_parts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    partname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    supplierid = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabel_parts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tabel_sales",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    total = table.Column<int>(type: "int", nullable: false),
                    carid = table.Column<int>(type: "int", nullable: false),
                    coustomerid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabel_sales", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tabel_suppliers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    suppliername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabel_suppliers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "parts_cars",
                columns: table => new
                {
                    listcarsid = table.Column<int>(type: "int", nullable: false),
                    listpartsid = table.Column<int>(type: "int", nullable: false),
                    fix = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parts_cars", x => new { x.listcarsid, x.listpartsid });
                    table.ForeignKey(
                        name: "FK_parts_cars_tabel_cars_listcarsid",
                        column: x => x.listcarsid,
                        principalTable: "tabel_cars",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_parts_cars_tabel_parts_listpartsid",
                        column: x => x.listpartsid,
                        principalTable: "tabel_parts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_parts_cars_listpartsid",
                table: "parts_cars",
                column: "listpartsid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "parts_cars");

            migrationBuilder.DropTable(
                name: "tabel_Costomer");

            migrationBuilder.DropTable(
                name: "tabel_sales");

            migrationBuilder.DropTable(
                name: "tabel_suppliers");

            migrationBuilder.DropTable(
                name: "tabel_cars");

            migrationBuilder.DropTable(
                name: "tabel_parts");
        }
    }
}
