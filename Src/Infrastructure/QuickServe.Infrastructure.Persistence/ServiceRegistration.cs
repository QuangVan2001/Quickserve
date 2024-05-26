using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Infrastructure.Persistence.Contexts;
using QuickServe.Infrastructure.Persistence.Repositories;
using System.Linq;
using System.Reflection;


namespace QuickServe.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(
               configuration.GetConnectionString("Server"),//cũ là GetConnectionString("SqlServer")
               b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.RegisterRepositories();
            


        }
        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            var interfaceType = typeof(IGenericRepository<>);
            var interfaces = Assembly.GetAssembly(interfaceType).GetTypes()
                .Where(p => p.GetInterface(interfaceType.Name.ToString()) != null);

            foreach (var item in interfaces)
            {
                var implimentation = Assembly.GetAssembly(typeof(GenericRepository<>)).GetTypes()
                    .FirstOrDefault(p => p.GetInterface(item.Name.ToString()) != null);
                services.AddTransient(item, implimentation);

            }

        }
    }
}
