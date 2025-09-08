using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecureLoginApp.Models;

namespace SecureLoginApp.Data
{
    // EF Core DbContext - holds Identity tables
    public class MyAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options)
            : base(options) { }
    }
}
