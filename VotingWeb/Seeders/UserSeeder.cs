using Microsoft.AspNetCore.Identity;
using VotingWeb.Data;

namespace VotingWeb.Seeders;
public static class UserSeeder
{
    public static async Task<WebApplication> SeedUsers(this WebApplication app)
    {
        using var scoped = app.Services.CreateScope();
        var ctx = scoped.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        if (!ctx.Users.Any())
        {
            ApplicationUser user = new()
            {
                Email="admin@step.org",
                NormalizedEmail="ADMIN@STEP.ORG",
                UserName="admin@step.org",
                NormalizedUserName="ADMIN@STEP.ORG",
                EmailConfirmed=true,
            };
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, "Admin@123");
            ctx.Users.Add(user);
            ctx.SaveChanges();
            await userManager.AddToRoleAsync(user,"Admin");
        }
        return app;
    }
}