using Microsoft.AspNetCore.Identity;
using QuickServe.Infrastructure.Identity.Models;
using System.Linq;
using System.Threading.Tasks;

namespace QuickServe.Infrastructure.Identity.Seeds
{
    public static class DefaultBasicUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "Admin",
                Email = "Admin@Admin.com",
                Name = "QuangVan",
                PhoneNumber = "0935182029",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (!userManager.Users.Any())
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Van@12345");
                    await userManager.AddToRoleAsync(defaultUser, "Admin");
                }

            }
        }
    }
}
