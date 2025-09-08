using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceSite.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string? Username { get; set; }

        [BindProperty]
        public string? Password { get; set; }

        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Simple hardcoded login check (replace with real user check later)
            if (Username == "admin" && Password == "123")
            {
                HttpContext.Session.SetString("Username", Username);
                return RedirectToPage("Index");
            }

            ErrorMessage = "Invalid credentials";
            return Page();
        }
    }
}
