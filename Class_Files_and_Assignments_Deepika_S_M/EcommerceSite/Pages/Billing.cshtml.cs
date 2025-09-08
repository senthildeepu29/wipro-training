using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcommerceSite.Models;

[PurchaseLogFilter]
public class BillingModel : PageModel
{
    public List<CartItem> Cart { get; set; }

    public void OnGet()
    {
        Cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
    }

    public IActionResult OnPost()
    {
        // Here you would handle billing form logic (e.g., save to DB)
        HttpContext.Session.Remove("Cart"); // clear cart
        return RedirectToPage("Index");
    }
}
