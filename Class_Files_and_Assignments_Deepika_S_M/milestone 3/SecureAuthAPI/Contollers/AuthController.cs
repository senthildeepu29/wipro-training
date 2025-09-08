using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SecureAuthAPI.Data;
using SecureAuthAPI.Models;
using SecureAuthAPI.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;

namespace SecureAuthAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(AppDbContext context, JwtTokenService jwtTokenService, ILogger<AuthController> logger) : ControllerBase
    {
        private readonly AppDbContext _context = context;
        private readonly JwtTokenService _jwtTokenService = jwtTokenService;
        private readonly ILogger<AuthController> _logger = logger;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return BadRequest("Invalid input");

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
            if (existingUser != null)
                return BadRequest("User already exists");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                Roles = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
                return BadRequest("Invalid input");

            var user = await _context.Users
                .Where(u => u.Username == login.Username)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                _logger.LogWarning($"Failed login attempt for username: {login.Username} at {DateTime.UtcNow}");
                return Unauthorized("Invalid username or password");
            }

            bool validPassword = BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash);

            if (!validPassword)
            {
                _logger.LogWarning($"Failed login attempt for username: {login.Username} at {DateTime.UtcNow}");
                return Unauthorized("Invalid username or password");
            }

            var token = _jwtTokenService.GenerateToken(user);

            return Ok(new
            {
                token,
                expires_in = 3600,
                user = new
                {
                    id = user.Id,
                    username = user.Username,
                    roles = user.Roles.Split(',')
                }
            });
        }

        [HttpPost("oauth")]
        public async Task<IActionResult> OAuthLogin([FromBody] OAuthRequest request)
        {
            if (string.IsNullOrEmpty(request.Provider) || string.IsNullOrEmpty(request.Token))
                return BadRequest("Invalid input");

            if (request.Provider.ToLower() != "google")
                return BadRequest("Unsupported provider");

            // Simulate Google verification
            string googleUsername = "google_user";  // Extract from validated token
            // string googleUserEmail = "google_user@example.com"; // Not used

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == googleUsername);
            if (user == null)
            {
                user = new User
                {
                    Username = googleUsername,
                    PasswordHash = "",
                    Roles = "User"
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }

            var jwtToken = _jwtTokenService.GenerateToken(user);

            return Ok(new
            {
                token = jwtToken,
                expires_in = 3600,
                user = new
                {
                    id = user.Id,
                    username = user.Username,
                    roles = user.Roles.Split(',')
                }
            });
        }

        // Request DTOs
        public class RegisterRequest
        {
            public string? Username { get; set; }
            public string? Password { get; set; }
        }

        public class LoginRequest
        {
            public string? Username { get; set; }
            public string? Password { get; set; }
        }

        public class OAuthRequest
        {
            public string? Provider { get; set; }
            public string? Token { get; set; }
        }
    }
}
