using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopForHome.Api.Controllers;
using ShopForHome.Api.Data;
using ShopForHome.Api.Models;
using ShopForHome.Api.Models.Dto;
using Xunit;
using System.Linq;

namespace ShopForHome.Tests
{
    public class OrdersControllerTests
    {
        private ShopContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "OrdersTestDb")
                .Options;
            var context = new ShopContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public void PlaceOrder_ShouldAddOrder()
        {
            var context = GetDbContext();
            var controller = new OrdersController(context);

            var dto = new OrderDto
            {
                FullName = "Test User",
                Email = "test@example.com",
                Address = "Test Street",
                City = "City",
                Zip = "12345",
                PaymentMethod = "COD",
                TotalAmount = 500,
                Items = new System.Collections.Generic.List<OrderItemDto>
                {
                    new OrderItemDto { ProductId = 1, Quantity = 2, Price = 250 }
                }
            };

            var result = controller.PlaceOrder(dto) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(1, context.Orders.Count());
        }

        [Fact]
        public void GetOrders_ShouldReturnOrders()
        {
            var context = GetDbContext();
            context.Orders.Add(new Order
            {
                FullName = "User A",
                Email = "a@example.com",
                ShippingAddress = "Street A",
                City = "City",
                Zip = "11111",
                PaymentMethod = "COD",
                TotalAmount = 100,
                Status = "Pending",
                Items = new System.Collections.Generic.List<OrderItem>
                {
                    new OrderItem { ProductId = 1, Quantity = 1, Price = 100 }
                }
            });
            context.SaveChanges();

            var controller = new OrdersController(context);
            var result = controller.GetOrders() as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void UpdateOrderStatus_ShouldChangeStatus()
        {
            var context = GetDbContext();
            var order = new Order
            {
                FullName = "User B",
                Email = "b@example.com",
                ShippingAddress = "Street B",
                City = "City",
                Zip = "22222",
                PaymentMethod = "COD",
                TotalAmount = 200,
                Status = "Pending",
                Items = new System.Collections.Generic.List<OrderItem>()
            };
            context.Orders.Add(order);
            context.SaveChanges();

            var controller = new OrdersController(context);
            var dto = new OrderStatusUpdateDto { Status = "Shipped" };

            var result = controller.UpdateOrderStatus(order.Id, dto) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal("Shipped", context.Orders.First().Status);
        }

        [Fact]
        public void DeleteOrder_ShouldRemoveOrder()
        {
            var context = GetDbContext();
            var order = new Order
            {
                FullName = "User C",
                Email = "c@example.com",
                ShippingAddress = "Street C",
                City = "City",
                Zip = "33333",
                PaymentMethod = "COD",
                TotalAmount = 300,
                Status = "Pending",
                Items = new System.Collections.Generic.List<OrderItem>()
            };
            context.Orders.Add(order);
            context.SaveChanges();

            var controller = new OrdersController(context);
            var result = controller.DeleteOrder(order.Id) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(0, context.Orders.Count());
        }
    }
}
