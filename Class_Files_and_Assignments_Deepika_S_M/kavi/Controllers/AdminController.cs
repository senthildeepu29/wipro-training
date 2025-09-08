using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureLoginApp.Controllers
{
    [Authorize(Roles = "Admin")] // entire controller secured for Admins only
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
