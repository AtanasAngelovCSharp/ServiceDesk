using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiceDesk.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, null, "atanas.angelov.2006@gmail.com", "Атанас Ангелов", "+359876658866" },
                    { 2, "Ул. Граг Игратиев №4", null, "Адроит Електроникс ЕООД", "+35988634598" },
                    { 3, "Бул. Дунав №190", "g.georgiev.77@gmail.com", "Георги Георгиев", "+359888907654" }
                });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "Id", "FullName", "PhoneNumber", "Specialization" },
                values: new object[,]
                {
                    { 1, "Петър Иванов", "+359888100200", "Лазерни принтери" },
                    { 2, "Наско Ангелов", "+35988634598", "Мастилено-струйни принтери" },
                    { 3, "Георги Георгиев", "+359888907654", "Лаптопи/Настолни Компютри" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Brand", "CustomerId", "Model", "SerialNumber", "Type" },
                values: new object[,]
                {
                    { 1, "Kyocera", 2, "ECOSYS M2540dn", "VCF8Z12345", 1 },
                    { 2, "Kyocera", 1, "ECOSYS M2540dn", "ECO321123", 1 },
                    { 3, "HP", 3, "LaserJet Pro M404dn", "LJ12345", 0 },
                    { 4, "Lenovo", 1, "ThinkPad T14", "982798834", 2 },
                    { 5, "Dell", 2, "OptiPlex 7090", "DELL67690096", 3 },
                    { 6, "Lenovo", 3, "ThinkPad T16", "45677654", 2 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequests",
                columns: new[] { "Id", "CompletedOn", "CreatedOn", "DeviceId", "EstimatedPrice", "ProblemDescription", "Status", "TechnicianId", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 20, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, 85.50m, "Хартията засяда при двустранен печат, на дисплея излиза грешка J0511.", 3, 1, "Засядане на хартия" },
                    { 2, null, new DateTime(2026, 10, 22, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 120m, "Лаптопът работи само на ток, батерията стои на 0% и не се зарежда.", 1, 3, "Не зарежда батерията" },
                    { 3, null, new DateTime(2026, 10, 21, 11, 0, 0, 0, DateTimeKind.Unspecified), 2, 210m, "Копията излизат бледи и с ивици, принтът от компютър е нормален.", 2, 1, "Бледо копиране" },
                    { 4, null, new DateTime(2026, 10, 24, 16, 45, 0, 0, DateTimeKind.Unspecified), 5, 0m, "Компютърът не се включва, вентилаторите се завъртат за секунда и спират.", 0, null, "Не стартира" },
                    { 5, new DateTime(2026, 10, 19, 12, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 18, 9, 50, 0, 0, DateTimeKind.Unspecified), 3, 65m, "При печат по листа остават черни петна на равни разстояния.", 3, 2, "Петна по листа" },
                    { 6, null, new DateTime(2026, 10, 25, 9, 30, 0, 0, DateTimeKind.Unspecified), 6, 0m, "Лаптопът се изключва сам след около 20 минути работа, долният капак е много горещ.", 0, null, "Прегрява и се изключва" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Technicians",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Technicians",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Technicians",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
