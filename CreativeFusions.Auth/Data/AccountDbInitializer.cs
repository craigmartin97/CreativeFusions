using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CreativeFusions.Auth.Data
{
    public static class AccountDbInitializer
    {
        public static void SeedDatabase(IServiceProvider services)
        {
            UserManager<AppUser> userManager = services.GetRequiredService<UserManager<AppUser>>();
            AppUser user = new AppUser("test@test.com", "Test Test", "01642444222")
            {
                EmailConfirmed = true
            };
            userManager.CreateAsync(user, "Password123").GetAwaiter().GetResult();
        }
    }
}