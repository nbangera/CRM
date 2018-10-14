using CRM.Models.Dbo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.DataStore
{


    public static class SeedExtension
    {
        public static IWebHost SeedData(this IWebHost host)
        {

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<CRMDBContext>();
                var userManager = services.GetRequiredService<UserManager<User>>();
                var roleManager = services.GetRequiredService<RoleManager<Role>>();

                DBSeedInitializer initializer = new DBSeedInitializer(userManager,roleManager,context);
                initializer.Seed();
            }
            return host;
        }

    }
}