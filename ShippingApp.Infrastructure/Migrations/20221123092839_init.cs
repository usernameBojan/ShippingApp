using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShippingApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanManageAdmins = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickupAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DateOfInquiry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Limitations",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    MinWeight = table.Column<double>(type: "float", nullable: false),
                    MaxWeight = table.Column<double>(type: "float", nullable: false),
                    MinVolume = table.Column<double>(type: "float", nullable: false),
                    MaxVolume = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Limitations", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Limitations_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VolumeRanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    MinVolume = table.Column<double>(type: "float", nullable: false),
                    HasMaxVolume = table.Column<bool>(type: "bit", nullable: false),
                    MaxVolume = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolumeRanges", x => new { x.CompanyId, x.Id });
                    table.ForeignKey(
                        name: "FK_VolumeRanges_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeightRanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    MinWeight = table.Column<double>(type: "float", nullable: false),
                    HasMaxWeight = table.Column<bool>(type: "bit", nullable: false),
                    MaxWeight = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IncrementalPriceStartingPoint = table.Column<double>(type: "float", nullable: false),
                    IncrementalPriceValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightRanges", x => new { x.CompanyId, x.Id });
                    table.ForeignKey(
                        name: "FK_WeightRanges_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CanManageAdmins", "FullName", "Password", "Username" },
                values: new object[] { 1, true, "Admin Adminsky", "x????1?Fx???!??", "adminxyz" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cargo4You" },
                    { 2, "ShipFaster" },
                    { 3, "MaltaShip" }
                });

            migrationBuilder.InsertData(
                table: "Limitations",
                columns: new[] { "CompanyId", "Id", "MaxVolume", "MaxWeight", "MinVolume", "MinWeight" },
                values: new object[,]
                {
                    { 1, 1, 2000.0, 20.0, 0.0, 0.0 },
                    { 2, 2, 1700.0, 30.0, 0.0, 10.0 },
                    { 3, 3, 0.0, 0.0, 500.0, 10.0 }
                });

            migrationBuilder.InsertData(
                table: "VolumeRanges",
                columns: new[] { "CompanyId", "Id", "HasMaxVolume", "MaxVolume", "MinVolume", "Price" },
                values: new object[,]
                {
                    { 1, 1, true, 1000.0, 0.0, 10.0 },
                    { 1, 2, true, 2000.0, 1000.0, 20.0 },
                    { 2, 3, true, 1000.0, 0.0, 11.99 },
                    { 2, 4, true, 1700.0, 1000.0, 21.989999999999998 },
                    { 3, 5, true, 1000.0, 500.0, 9.5 },
                    { 3, 6, true, 2000.0, 1000.0, 19.5 },
                    { 3, 7, true, 5000.0, 2000.0, 48.5 },
                    { 3, 8, false, 0.0, 5000.0, 147.5 }
                });

            migrationBuilder.InsertData(
                table: "WeightRanges",
                columns: new[] { "CompanyId", "Id", "HasMaxWeight", "IncrementalPriceStartingPoint", "IncrementalPriceValue", "MaxWeight", "MinWeight", "Price" },
                values: new object[,]
                {
                    { 1, 1, true, 0.0, 0.0, 2.0, 0.0, 15.0 },
                    { 1, 2, true, 0.0, 0.0, 15.0, 2.0, 18.0 },
                    { 1, 3, true, 0.0, 0.0, 20.0, 15.0, 35.0 },
                    { 2, 4, true, 0.0, 0.0, 15.0, 10.0, 16.5 },
                    { 2, 5, true, 0.0, 0.0, 25.0, 15.0, 36.5 },
                    { 2, 6, true, 25.0, 0.41699999999999998, 30.0, 25.0, 40.0 },
                    { 3, 7, true, 0.0, 0.0, 20.0, 10.0, 16.989999999999998 },
                    { 3, 8, true, 0.0, 0.0, 30.0, 20.0, 33.990000000000002 },
                    { 3, 9, false, 25.0, 0.40999999999999998, 0.0, 30.0, 43.990000000000002 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Limitations");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "VolumeRanges");

            migrationBuilder.DropTable(
                name: "WeightRanges");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
