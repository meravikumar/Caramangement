using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class spToShowAllCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Details_CarId",
                table: "Details");

            migrationBuilder.CreateIndex(
                name: "IX_Details_CarId",
                table: "Details",
                column: "CarId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Details_CarId",
                table: "Details");

            migrationBuilder.CreateIndex(
                name: "IX_Details_CarId",
                table: "Details",
                column: "CarId");
        }
    }
}
