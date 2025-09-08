using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopForHomeApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopForHomeApi.Services {
    public class AuthService {
        private readonly IConfiguration _config;
        public AuthService(IConfiguration config) { _config = config; }

        public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
        public bool VerifyPassword(string password, string hash) => BCrypt.Net.BCrypt.Verify(password, hash);

        public string GenerateJwtToken(User user) {
            var key = _config["Jwt:Key"];
            var issuer = _config["Jwt:Issuer"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(issuer, issuer, claims, expires: DateTime.UtcNow.AddDays(7), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
