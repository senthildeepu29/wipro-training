using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcommerceSite.Models;
using System.Collections.Generic;
using System.Linq;

namespace EcommerceSite.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; set; }

        public void OnGet()
        {
            Products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10, ImageUrl = "/images/product1.jpg" },
                new Product { Id = 2, Name = "Product 2", Price = 20, ImageUrl = "/images/product2.jpg" },
                new Product { Id = 3, Name = "Product 3", Price = 30, ImageUrl = "/images/product3.jpg" },
                new Product { Id = 4, Name = "Product 4", Price = 40, ImageUrl = "/images/product4.jpg" }
            };
        }

        public IActionResult OnPostAddToCart(int productId)
        {
            // Get existing cart from session or create new
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            // Find product from Products list or recreate here
            var product = Products.FirstOrDefault(p => p.Id == productId) ??
                          new List<Product> {
                              new Product { Id = 1, Name = "Product 1", Price = 10, ImageUrl = "/images/product1.jpg" },
                              new Product { Id = 2, Name = "Product 2", Price = 20, ImageUrl = "/images/product2.jpg" },
                              new Product { Id = 3, Name = "Product 3", Price = 30, ImageUrl = "/images/product3.jpg" },
                              new Product { Id = 4, Name = "Product 4", Price = 40, ImageUrl = "/images/product4.jpg" }
                          }.FirstOrDefault(p => p.Id == productId);

            if (product == null)
                return Page();  // Product not found, stay on page

            var existing = cart.FirstOrDefault(c => c.Product.Id == productId);
            if (existing != null)
            {
                existing.Quantity++;
            }
            else
            {
                cart.Add(new CartItem { Product = product, Quantity = 1 });
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return RedirectToPage("Cart");
        }
    }
}
