using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class spGetAllCompanyList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sProcedure = @"CREATE PROCEDURE GetAllCompanyList
                    AS
                    BEGIN
                         SELECT * FROM Companys;
                    END";
            migrationBuilder.Sql(sProcedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sProcedure = @"Drop procedure GetAllCompanyList";
            migrationBuilder.Sql(sProcedure);
        }
    }
}
