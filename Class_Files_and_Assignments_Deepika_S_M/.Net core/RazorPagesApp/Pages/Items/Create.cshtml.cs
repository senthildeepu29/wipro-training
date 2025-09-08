using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace RazorPagesApp.Pages.Items
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public string NewItem { get; set; }

        public IActionResult OnPost()
        {
            List<string> items = new();

            if (TempData["Items"] is string serializedItems)
            {
                items = JsonSerializer.Deserialize<List<string>>(serializedItems);
            }

            items.Add(NewItem);
            TempData["Items"] = JsonSerializer.Serialize(items);

            return RedirectToPage("Index");
        }
    }
}
