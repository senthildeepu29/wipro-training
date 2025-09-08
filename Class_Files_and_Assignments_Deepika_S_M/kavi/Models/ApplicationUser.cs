using Microsoft.AspNetCore.Identity;

namespace SecureLoginApp.Models
{
    // Extend IdentityUser later with profile fields if needed
    public class ApplicationUser : IdentityUser
    {
        // e.g. public string FullName { get; set; }
    }
}
