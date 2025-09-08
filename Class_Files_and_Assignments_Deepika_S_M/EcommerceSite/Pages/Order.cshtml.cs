using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcommerceSite.Models;

public class OrderModel : PageModel
{
    public List<CartItem> Cart { get; set; }

    public void OnGet()
    {
        Cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
    }
}
