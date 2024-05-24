using System.Collections.Generic;
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
        // Seed Default Users
        var users = new List<ApplicationUser>
        {
            new ApplicationUser
            {
                UserName = "Admin",
                Email = "Admin@Admin.com",
                Name = "QuangVan",
                PhoneNumber = "0935182029",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            },
            new ApplicationUser
            {
                UserName = "CustomerUser",
                Email = "customer@domain.com",
                Name = "Customer Name",
                PhoneNumber = "0935111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            },
            new ApplicationUser
            {
                UserName = "StaffUser",
                Email = "staff@domain.com",
                Name = "Staff Name",
                PhoneNumber = "0935222222",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            },
            new ApplicationUser
            {
                UserName = "StoreManagerUser",
                Email = "storemanager@domain.com",
                Name = "Store Manager Name",
                PhoneNumber = "0935333333",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            },
            new ApplicationUser
            {
                UserName = "BrandManagerUser",
                Email = "brandmanager@domain.com",
                Name = "Brand Manager Name",
                PhoneNumber = "0935444444",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            }
        };

        var roles = new List<string> { "Admin", "Customer", "Staff", "Store_Manager", "Brand_Manager" };
        var userPasswords = new Dictionary<string, string>
        {
            { "Admin", "Van@12345" },
            { "CustomerUser", "Customer@12345" },
            { "StaffUser", "Staff@12345" },
            { "StoreManagerUser", "StoreManager@12345" },
            { "BrandManagerUser", "BrandManager@12345" }
        };

        foreach (var user in users)
        {
            if (!userManager.Users.Any(u => u.Email == user.Email))
            {
                var result = await userManager.CreateAsync(user, userPasswords[user.UserName]);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roles[users.IndexOf(user)]);
                }
            }
        }
    }
    }
}
