using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorProductApp.Models;

namespace RazorProductApp.Pages
{
    public class ProductPageModel : PageModel
    {
        [BindProperty]
        public Product? NewProduct { get; set; }

        public List<Product> ProductList { get; set; } = new();

        public void OnGet()
        {
            // For demo purposes, add some dummy data
            ProductList.Add(new Product
            {
                ProductID = 1,
                Name = "Laptop",
                Description = "Gaming laptop",
                Categories = new List<Category>
                {
                    new Category { CategoryID = 1, Name = "Electronics" },
                    new Category { CategoryID = 2, Name = "Computers" }
                }
            });
        }

        public IActionResult OnPost()
        {
            // Save logic here (in-memory or DB)
            return RedirectToPage();
        }
    }
}
