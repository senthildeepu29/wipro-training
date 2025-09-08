using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopForHomeApi.Data;
using ShopForHomeApi.Dtos;
using ShopForHomeApi.Models;
using ShopForHomeApi.Services;

namespace ShopForHomeApi.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase {
        private readonly ApplicationDbContext _db;
        private readonly AuthService _auth;
        public UsersController(ApplicationDbContext db, AuthService auth) { _db = db; _auth = auth; }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto) {
            if (await _db.Users.AnyAsync(u => u.Email == dto.Email)) return BadRequest("Email already exists");
            var user = new User { Username = dto.Username, Email = dto.Email, PasswordHash = _auth.HashPassword(dto.Password) };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return Ok(new { user.Id, user.Username, user.Email });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto) {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !_auth.VerifyPassword(dto.Password, user.PasswordHash)) return Unauthorized();
            var token = _auth.GenerateJwtToken(user);
            return Ok(new { token, user = new { user.Id, user.Username, user.Email, user.Role } });
        }
    }
}
