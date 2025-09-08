using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecureLoginApp.Models;
using SecureLoginApp.ViewModels;

namespace SecureLoginApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signIn;
        private readonly UserManager<ApplicationUser> _users;
        private readonly IDataProtector _protector;

        public AccountController(
            SignInManager<ApplicationUser> signIn,
            UserManager<ApplicationUser> users,
            IDataProtectionProvider dpProvider)
        {
            _signIn = signIn;
            _users = users;
            _protector = dpProvider.CreateProtector("SecureLoginApp.Protect");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid) return View(vm);

            var user = await _users.FindByNameAsync(vm.Username);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View(vm);
            }

            var result = await _signIn.PasswordSignInAsync(user, vm.Password, vm.RememberMe, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                var roles = await _users.GetRolesAsync(user);
                // store a small protected message to prove DataProtection usage
                TempData["Protected"] = _protector.Protect($"{user.UserName}|Authenticated");

                if (roles.Contains("Admin"))
                {
                    TempData["Message"] = "Welcome, Admin! You have access to the Admin Dashboard.";
                    return RedirectToAction("Dashboard", "Admin");
                }

                TempData["Message"] = "Welcome, User! Here is your profile information.";
                return RedirectToAction("Profile", "User");
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Account locked out - try again later.");
                return View(vm);
            }

            ModelState.AddModelError("", "Login failed.");
            return View(vm);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signIn.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            Response.StatusCode = 403;
            return View();
        }
    }
}
