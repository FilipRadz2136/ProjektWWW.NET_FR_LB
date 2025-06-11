using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjektWWW.NET_FR_LB.Migrations
{
    /// <inheritdoc />
    public partial class seedwaluty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Waluty",
                columns: new[] { "Id", "Kod", "Kraj", "Nazwa", "Symbol" },
                values: new object[,]
                {
                    { 1, "USD", "🇺🇸", "Dolar amerykański", "$" },
                    { 2, "EUR", "🇪🇺", "Euro", "€" },
                    { 3, "GBP", "🇬🇧", "Funt brytyjski", "£" },
                    { 4, "PLN", "🇵🇱", "Złoty polski", "zł" },
                    { 5, "JPY", "🇯🇵", "Jen japoński", "¥" },
                    { 6, "CHF", "🇨🇭", "Frank szwajcarski", "CHF" },
                    { 7, "AUD", "🇦🇺", "Dolar australijski", "A$" },
                    { 8, "CAD", "🇨🇦", "Dolar kanadyjski", "C$" },
                    { 9, "NOK", "🇳🇴", "Korona norweska", "kr" },
                    { 10, "SEK", "🇸🇪", "Korona szwedzka", "kr" },
                    { 11, "CNY", "🇨🇳", "Juan chiński", "¥" },
                    { 12, "NZD", "🇳🇿", "Dolar nowozelandzki", "NZ$" },
                    { 13, "CZK", "🇨🇿", "Korona czeska", "Kč" },
                    { 14, "DKK", "🇩🇰", "Korona duńska", "kr" },
                    { 15, "HUF", "🇭🇺", "Forint węgierski", "Ft" },
                    { 16, "ZAR", "🇿🇦", "Rand południowoafrykański", "R" },
                    { 17, "ILS", "🇮🇱", "Nowy izraelski szekel", "₪" },
                    { 18, "MXN", "🇲🇽", "Peso meksykańskie", "$" },
                    { 19, "TRY", "🇹🇷", "Lira turecka", "₺" },
                    { 20, "SGD", "🇸🇬", "Dolar singapurski", "S$" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Waluty",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Waluty",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Waluty",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Waluty",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Waluty",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Waluty",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Waluty",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Waluty",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Waluty",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Waluty",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Waluty",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Waluty",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Waluty",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Waluty",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Waluty",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Waluty",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Waluty",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Waluty",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Waluty",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Waluty",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
