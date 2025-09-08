using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopForHome.Api.Migrations
{
    /// <inheritdoc />
    public partial class MakeImageUrlNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "ImageUrl", "Name", "Price", "Rating", "Stock" },
                values: new object[] { "arts", "https://example.com/wallarts.jpg", "wall arts", 6000m, 4.8m, 500 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "ImageUrl", "Name", "Price", "Rating", "Stock" },
                values: new object[] { "lights", "https://example.com/lamp.jpg", "lamp", 7600m, 4.5m, 1000 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { "chair", "https://example.com/chair.jpg", "wooden chair", 1200m, 700 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "ImageUrl", "Name", "Price", "Rating", "Stock" },
                values: new object[] { "cot", "https://example.com/cot.jpg", "modern cot", 25000m, 4.6m, 1000 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "ImageUrl", "Name", "Price", "Rating", "Stock" },
                values: new object[] { "plants", "https://example.com/plants.jpg", "artificial plant decors", 670m, 5.0m, 20000 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$2YHeolsGh2jHY5aAPfqrSuRih3Q0mo/680/nBxge2tcop6v0whddO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "ImageUrl", "Name", "Price", "Rating", "Stock" },
                values: new object[] { "Electronics", "https://example.com/laptop.jpg", "Laptop", 999.99m, 4.5m, 50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "ImageUrl", "Name", "Price", "Rating", "Stock" },
                values: new object[] { "Electronics", "https://example.com/smartphone.jpg", "Smartphone", 699.99m, 4.3m, 100 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[] { "Accessories", "https://example.com/headphones.jpg", "Headphones", 199.99m, 200 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "ImageUrl", "Name", "Price", "Rating", "Stock" },
                values: new object[] { "Home Appliances", "https://example.com/coffeemaker.jpg", "Coffee Maker", 49.99m, 3.8m, 80 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "ImageUrl", "Name", "Price", "Rating", "Stock" },
                values: new object[] { "Electronics", "https://example.com/console.jpg", "Gaming Console", 399.99m, 4.7m, 30 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$O/bsi9Lph5S2OcQ9DayQh..wQ0TC.GvsyIr9x8sLkU3U8qjHxDXTy");
        }
    }
}
