using Microsoft.AspNetCore.Identity;

public static class IdentityDataInitializer
{
    public static async Task SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        if (!await roleManager.RoleExistsAsync("Admin"))
            await roleManager.CreateAsync(new IdentityRole("Admin"));

        if (!await roleManager.RoleExistsAsync("User"))
            await roleManager.CreateAsync(new IdentityRole("User"));

        var admin = await userManager.FindByNameAsync("admin");
        if (admin == null)
        {
            var user = new IdentityUser { UserName = "admin", Email = "admin@example.com", EmailConfirmed = true };
            var result = await userManager.CreateAsync(user, "Admin@123");
            if (result.Succeeded)
                await userManager.AddToRoleAsync(user, "Admin");
        }

        var user1 = await userManager.FindByNameAsync("user1");
        if (user1 == null)
        {
            var user = new IdentityUser { UserName = "user1", Email = "user1@example.com", EmailConfirmed = true };
            var result = await userManager.CreateAsync(user, "User@123");
            if (result.Succeeded)
                await userManager.AddToRoleAsync(user, "User");
        }
    }
}
