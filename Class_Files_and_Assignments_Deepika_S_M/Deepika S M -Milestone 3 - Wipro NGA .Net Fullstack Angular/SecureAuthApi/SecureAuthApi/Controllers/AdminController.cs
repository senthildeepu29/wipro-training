using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureAuthApi.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("dashboard")]
        public IActionResult GetAdminDashboard()
        {
            return Ok(new { message = "Welcome to the Admin dashboard." });
        }
    }
}
