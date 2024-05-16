using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingCarandCompanydatanew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companys",
                columns: new[] { "CompanyId", "CEO", "CompanyName", "EstablishedDate", "IsFinanceProvider", "Location" },
                values: new object[] { 1, "Ravi sharma", "Kia", new DateOnly(2020, 1, 1), true, "Spain" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "CarModel", "CarName", "CompanyId", "Insurance", "Price" },
                values: new object[,]
                {
                    { 1, "Alpha", "Kia seltos", 1, true, 14m },
                    { 2, "Alpha", "Kia seltos", 1, true, 14m },
                    { 3, "Alpha", "Kia seltos", 1, true, 14m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companys",
                keyColumn: "CompanyId",
                keyValue: 1);
        }
    }
}
