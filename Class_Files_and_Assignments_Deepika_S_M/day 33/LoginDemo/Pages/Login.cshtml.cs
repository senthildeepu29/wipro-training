using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginDemo.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public bool LoginFailed { get; set; }

        public class InputModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public void OnGet()
        {
            LoginFailed = false;
        }

        public IActionResult OnPost()
        {
            // Replace this logic with real authentication
            if (Input.Username == "admin" && Input.Password == "password")
            {
                return RedirectToPage("Index");
            }

            LoginFailed = true;
            return Page();
        }
    }
}
