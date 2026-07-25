using Microsoft.AspNetCore.Identity;

namespace VotingWeb.Seeders;
public static class RoleSeeder
{
    public static async Task SeedRoles(this WebApplication app)
    {
        using var scoped = app.Services.CreateScope();
        var services = scoped.ServiceProvider;
        var ctx = services.GetRequiredService<RoleManager<IdentityRole>>();
        if(!ctx.Roles.Any())
        {
            await ctx.CreateAsync(new()
            {
                Id="Admin",
                Name="Admin",
                NormalizedName="Admin",
            });
            await ctx.CreateAsync(new()
            {
                Id="User",
                Name="User",
                NormalizedName="User",
            });
        }
    }
}