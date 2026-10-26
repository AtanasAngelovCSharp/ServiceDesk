using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceDesk.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixCustomerAddressTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: "Ул. Граф Игнатиев №4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: "Ул. Граг Игратиев №4");
        }
    }
}
