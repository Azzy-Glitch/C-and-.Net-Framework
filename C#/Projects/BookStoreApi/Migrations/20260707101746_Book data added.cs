using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApi.Migrations
{
    /// <inheritdoc />
    public partial class Bookdataadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "Stock", "Title" },
                values: new object[,]
                {
                    { 1, "John", 500.0, 10, "C# Basics" },
                    { 2, "Smith", 700.0, 5, "ASP.NET Guide" },
                    { 3, "Robert Martin", 1200.0, 8, "Clean Code" },
                    { 4, "Andrew Hunt", 1500.0, 6, "The Pragmatic Programmer" },
                    { 5, "Erich Gamma", 1800.0, 4, "Design Patterns" },
                    { 6, "Thomas H. Cormen", 2000.0, 3, "Introduction to Algorithms" },
                    { 7, "Andrew Stellman", 900.0, 7, "Head First C#" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
