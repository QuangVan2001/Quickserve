using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickServe.Application.Interfaces;
using QuickServe.Infrastructure.FileManager.Contexts;
using QuickServe.Infrastructure.FileManager.Services;

namespace QuickServe.Infrastructure.FileManager
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddFileManagerInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FileManagerDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("FileManagerConnection"));
            });
            services.AddScoped<IFileManagerService, FileManagerService>();

            services.AddScoped<IStorageService, BlobStorageService>();

            services.AddSingleton(x => new BlobServiceClient(configuration.GetConnectionString("AzureBlobStorage")));

            return services;

        }
    }
}