using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecureAuthAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? PasswordHash { get; set; }

        // Store roles as comma separated values (simplified)
        public string? Roles { get; set; }
    }
}
