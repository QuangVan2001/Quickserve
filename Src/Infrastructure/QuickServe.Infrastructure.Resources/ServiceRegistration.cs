using Microsoft.Extensions.DependencyInjection;
using QuickServe.Application.Interfaces;
using QuickServe.Infrastructure.Resources.Services;

namespace QuickServe.Infrastructure.Resources
{
    public static class ServiceRegistration
    {
        public static void AddResourcesInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<ITranslator, Translator>();
        }
    }
}
