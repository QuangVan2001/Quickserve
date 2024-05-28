using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QuickServe.Infrastructure.Identity.Contexts
{
    public class AppIdentityContext : IdentityDbContext<IdentityUser>
    {
        public AppIdentityContext(DbContextOptions<AppIdentityContext> options) : base(options)
        {
        }
    }
}
