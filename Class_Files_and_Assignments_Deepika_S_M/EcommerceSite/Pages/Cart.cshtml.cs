using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcommerceSite.Models;

public class CartModel : PageModel
{
    public List<CartItem> Cart { get; set; }

    public void OnGet()
    {
        Cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
    }

    public IActionResult OnPostRemove(int productId)
    {
        var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
        var item = cart.FirstOrDefault(i => i.Product.Id == productId);
        if (item != null)
            cart.Remove(item);

        HttpContext.Session.SetObjectAsJson("Cart", cart);
        return RedirectToPage();
    }
}
