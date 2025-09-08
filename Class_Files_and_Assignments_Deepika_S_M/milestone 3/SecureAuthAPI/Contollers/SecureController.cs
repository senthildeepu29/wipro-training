using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureAuthAPI.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SecureAuthAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class SecureDataController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SecureDataController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("secure-data")]
        [Authorize]
        public IActionResult GetSecureData()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

            if (userId == null)
                return Unauthorized();

            return Ok(new
            {
                message = "Secure data accessed successfully.",
                data = new
                {
                    user_id = int.Parse(userId),
                    secure_info = "This is some sensitive user data."
                }
            });
        }

        [HttpGet("admin/dashboard")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAdminDashboard()
        {
            return Ok(new
            {
                message = "Welcome to Admin Dashboard."
            });
        }
    }
}
