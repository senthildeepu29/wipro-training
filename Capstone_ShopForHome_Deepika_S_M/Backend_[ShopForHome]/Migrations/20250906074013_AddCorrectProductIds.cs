using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopForHome.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCorrectProductIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "OrderId1",
                table: "OrderItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "ImageUrl", "Name", "Price", "Rating", "Stock" },
                values: new object[,]
                {
                    { 6, "arts", "https://example.com/wallarts.jpg", "Wall Arts", 6000m, 4.8m, 500 },
                    { 10, "plants", "https://example.com/plantdecor.jpg", "Artificial Plant Decors", 670m, 5.0m, 20000 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$kRSSeaSYq0PGjB1MJ0.s2ubruIU5n5CsvKDhVZFV02z4rkvwPs1.O");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId1",
                table: "OrderItems",
                column: "OrderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId1",
                table: "OrderItems",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId1",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderId1",
                table: "OrderItems");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "OrderItems");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "ImageUrl", "Name", "Price", "Rating", "Stock" },
                values: new object[,]
                {
                    { 1, "arts", "https://example.com/wallarts.jpg", "wall arts", 6000m, 4.8m, 500 },
                    { 2, "lights", "https://example.com/lamp.jpg", "lamp", 7600m, 4.5m, 1000 },
                    { 3, "chair", "https://example.com/chair.jpg", "wooden chair", 1200m, 4.0m, 700 },
                    { 4, "cot", "https://example.com/cot.jpg", "modern cot", 25000m, 4.6m, 1000 },
                    { 5, "plants", "https://example.com/plants.jpg", "artificial plant decors", 670m, 5.0m, 20000 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$2YHeolsGh2jHY5aAPfqrSuRih3Q0mo/680/nBxge2tcop6v0whddO");
        }
    }
}
