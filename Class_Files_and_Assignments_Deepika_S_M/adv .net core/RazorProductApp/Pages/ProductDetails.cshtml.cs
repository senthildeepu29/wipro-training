using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorProductApp.Pages
{
    public class ProductDetailsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ProductID { get; set; }

        public void OnGet()
        {
            // You can load the product details using ProductID from a database or in-memory collection
        }
    }
}
