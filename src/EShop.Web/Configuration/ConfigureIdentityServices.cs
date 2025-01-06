using EShop.Core.Entities;
using EShop.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace EShop.Web.Configuration
{
    public static class ConfigureIdentityServices
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            //Add identity services
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<SignInManager<ApplicationUser>>();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });

            return services;
        }

        public static async Task InitializeScope(this IServiceScope scope)
        {
            //Get services
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<string>>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            //Initialize roles
            string[] roles = ["Admin", "User"];

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole<string>(role) { Id = Guid.NewGuid().ToString()} );
                }
            }

            //Initialize admin user
            var adminUser = await userManager.FindByNameAsync("admin");
            if (adminUser is null)
            {
                adminUser = new ApplicationUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "admin",
                    Email = "admin@eshop.eu",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "administrator");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
                else
                {
                    throw new Exception(
                        "Could not create admin user",
                        new Exception(string.Join(", ", result.Errors.Select(e => e.Description)))
                        );
                }
            }
        }
    }
}
