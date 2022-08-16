using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop_PV016.Migrations
{
    public partial class Editmodelcreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Processor");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "The world's best desktop processor delivers superior gaming performance.", "AMD Ryzen 7 5700G", 700.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "New AMD Zen Architecture Uses Powerful Execution Engine and Supports Simultaneous Multithreading (SMT)", "AMD Ryzen 5 1600", 250.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Unlocked 12th Gen Intel Core desktop processor optimized for enthusiast gamers and serious creators", "Intel Core i9-12900K", 900.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "ASUS Prime series motherboards offer a reinforced power system, the ability to organize full-fledged component cooling, and intelligent configuration tools.", "Asus Prime B550M-K" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "The Prime X570 series is made for serious people who prefer to use their Ryzen processors for more productive work.", "ASUS PRIME X570-P", 300.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Z690 AORUS ELITE motherboard adopts 16+1+2 phase digital processor power supply scheme", "Gigabyte Z690 Aorus Elite", 350.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Proccessor");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Proccessor", "Ryzen 5 2600", 300.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Proccessor", "Ryzen 5 1600", 200.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Proccessor", "Intel core i5 9400f", 350.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Motherboard", "Asus Prime H510M-K" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Motherboard", "MSI MPG Z490 Gaming Plus", 210.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Motherboard", "Gigabyte Z690 UD", 400.0 });
        }
    }
}
