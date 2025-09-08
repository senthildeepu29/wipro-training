using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApp.Pages.Items
{
    public class IndexModel : PageModel
    {
        public List<string> Items { get; set; } = new();

        public void OnGet()
        {
            if (TempData["Items"] is string serializedItems)
            {
                Items = System.Text.Json.JsonSerializer.Deserialize<List<string>>(serializedItems);
            }
        }
    }
}
