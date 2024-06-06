using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickServe.Infrastructure.Identity.Models;
using System;

namespace QuickServe.Infrastructure.Identity.Contexts
{
    public class AppIdentityContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public AppIdentityContext(DbContextOptions<AppIdentityContext> options) : base(options)
        {

        }
    }
}
