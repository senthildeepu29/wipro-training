using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SecureLoginApp.Data;
using SecureLoginApp.Models;

var builder = WebApplication.CreateBuilder(args);

// ---------- DbContext (InMemory for demo) ----------
builder.Services.AddDbContext<MyAppDbContext>(opts =>
    opts.UseInMemoryDatabase("SecureLoginDb"));

// ---------- Identity ----------
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // reasonable demo settings; tighten for production
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.User.RequireUniqueEmail = false;
})
    .AddEntityFrameworkStores<MyAppDbContext>()
    .AddDefaultTokenProviders();

// Configure cookie paths to use our AccessDenied page
builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.LoginPath = "/Account/Login";
    opts.AccessDeniedPath = "/Account/AccessDenied";
    opts.SlidingExpiration = true;
});

// Auto-validate antiforgery tokens on POST/PUT/DELETE by default
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryTokenAttribute());
});

// Data Protection (example usage)
builder.Services.AddDataProtection();

var app = builder.Build();

// Seed roles and demo users on startup
using (var scope = app.Services.CreateScope())
{
    var svc = scope.ServiceProvider;
    await SeedData.SeedAsync(svc);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Force HTTPS
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

static class SeedData
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        var roleMgr = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userMgr = services.GetRequiredService<UserManager<ApplicationUser>>();

        // ensure roles
        foreach (var r in new[] { "Admin", "User" })
            if (!await roleMgr.RoleExistsAsync(r))
                await roleMgr.CreateAsync(new IdentityRole(r));

        // admin
        if (await userMgr.FindByNameAsync("admin") == null)
        {
            var admin = new ApplicationUser { UserName = "admin", Email = "admin@example.local" };
            await userMgr.CreateAsync(admin, "Admin@123"); // Identity hashes automatically
            await userMgr.AddToRoleAsync(admin, "Admin");
        }

        // normal user
        if (await userMgr.FindByNameAsync("user1") == null)
        {
            var user = new ApplicationUser { UserName = "user1", Email = "user1@example.local" };
            await userMgr.CreateAsync(user, "User@123");
            await userMgr.AddToRoleAsync(user, "User");
        }
    }
}