using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DealershipManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class ApplyNewChangesToCarTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductionYear",
                table: "Cars",
                newName: "ProdYear");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProdYear",
                table: "Cars",
                newName: "ProductionYear");
        }
    }
}
