// using Xunit;
// using ShopForHome.Api.Controllers;
// using ShopForHome.Api.Data;
// using Microsoft.EntityFrameworkCore;

// public class ProductsControllerTests
// {
//     private ShopContext GetDbContext()
//     {
//         var options = new DbContextOptionsBuilder<ShopContext>()
//             .UseInMemoryDatabase(databaseName: "TestDb")
//             .Options;
//         return new ShopContext(options);
//     }

//     [Fact]
//     public void GetAllProducts_ReturnsEmpty_WhenNoProducts()
//     {
//         // Arrange
//         var context = GetDbContext();
//         var controller = new ProductsController(context);

//         // Act
//         var result = controller.GetAll(null, null, null, null);

//         // Assert
//         Assert.NotNull(result);
//     }
// }

using Microsoft.EntityFrameworkCore;
using ShopForHome.Api.Controllers;
using ShopForHome.Api.Data;
using ShopForHome.Api.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ShopForHome.Tests
{
    public class ProductsControllerTests
    {
        private ShopContext GetContext()
        {
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_" + Guid.NewGuid())
                .Options;

            return new ShopContext(options);
        }

        [Fact]
        public void CreateProduct_ShouldAddProduct()
        {
            using var context = GetContext();
            var controller = new ProductsController(context);

            var product = new Product { Name = "Test Phone", Price = 500, Category = "Electronics", Stock = 10, Rating = 4, ImageUrl = "test.jpg" };
            var result = controller.Create(product);

            Assert.Equal(1, context.Products.Count());
            Assert.Equal("Test Phone", context.Products.First().Name);
        }

        [Fact]
        public void GetProductById_ShouldReturnProduct()
        {
            using var context = GetContext();
            var controller = new ProductsController(context);

            var product = new Product { Name = "Laptop", Price = 1000, Category = "Electronics", Stock = 5, Rating = 5, ImageUrl = "laptop.jpg" };
            context.Products.Add(product);
            context.SaveChanges();

            var result = controller.Get(product.Id) as OkObjectResult;
            var returnedProduct = result?.Value as Product;

            Assert.NotNull(returnedProduct);
            Assert.Equal("Laptop", returnedProduct.Name);
        }

        [Fact]
        public void UpdateProduct_ShouldModifyProduct()
        {
            using var context = GetContext();
            var controller = new ProductsController(context);

            var product = new Product { Name = "TV", Price = 800, Category = "Electronics", Stock = 3, Rating = 3, ImageUrl = "tv.jpg" };
            context.Products.Add(product);
            context.SaveChanges();

            product.Name = "Smart TV";
            controller.Update(product.Id, product);

            var updated = context.Products.First();
            Assert.Equal("Smart TV", updated.Name);
        }

        [Fact]
        public void DeleteProduct_ShouldRemoveProduct()
        {
            using var context = GetContext();
            var controller = new ProductsController(context);

            var product = new Product { Name = "Headphones", Price = 50, Category = "Electronics", Stock = 15, Rating = 4, ImageUrl = "headphones.jpg" };
            context.Products.Add(product);
            context.SaveChanges();

            controller.Delete(product.Id);

            Assert.Empty(context.Products);
        }

        [Fact]
        public void GetAll_WithMinPriceFilter_ShouldReturnFilteredProducts()
        {
            using var context = GetContext();
            var controller = new ProductsController(context);

            context.Products.Add(new Product { Name = "Cheap Item", Price = 50, Category = "General", Stock = 20, Rating = 3, ImageUrl = "cheap.jpg" });
            context.Products.Add(new Product { Name = "Expensive Item", Price = 1000, Category = "General", Stock = 5, Rating = 5, ImageUrl = "expensive.jpg" });
            context.SaveChanges();

            var result = controller.GetAll(minPrice: 500, category: null, maxPrice: null, minRating: null) as OkObjectResult;
            var products = result?.Value as List<Product>;

            Assert.Single(products);
            Assert.Equal("Expensive Item", products.First().Name);
        }
    }
}

