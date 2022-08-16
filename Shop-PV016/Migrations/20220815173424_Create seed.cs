using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop_PV016.Migrations
{
    public partial class Createseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ShowOrder" },
                values: new object[] { 1, "Proccessor", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ShowOrder" },
                values: new object[] { 2, "Motherboard", 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price", "ShortDescription" },
                values: new object[,]
                {
                    { 1, 1, "Proccessor", null, "Ryzen 5 2600", 300.0, null },
                    { 2, 1, "Proccessor", null, "Ryzen 5 1600", 200.0, null },
                    { 3, 1, "Proccessor", null, "Intel core i5 9400f", 350.0, null },
                    { 4, 2, "Motherboard", null, "Asus Prime H510M-K", 190.0, null },
                    { 5, 2, "Motherboard", null, "MSI MPG Z490 Gaming Plus", 210.0, null },
                    { 6, 2, "Motherboard", null, "Gigabyte Z690 UD", 400.0, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
