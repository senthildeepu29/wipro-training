using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace SecureLoginApp.Controllers
{
    [Authorize(Roles = "User,Admin")] // both roles can see profile
    public class UserController : Controller
    {
        private readonly IDataProtector _protector;

        public UserController(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("SecureLoginApp.Protect");
        }

        public IActionResult Profile()
        {
            if (TempData["Protected"] is string prot)
            {
                try
                {
                    ViewBag.ProtectedMessage = _protector.Unprotect(prot);
                }
                catch { /* ignore if tampered */ }
            }
            return View();
        }
    }
}
