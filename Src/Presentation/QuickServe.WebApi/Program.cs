using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuickServe.Application;
using QuickServe.Application.Interfaces;
using QuickServe.Infrastructure.FileManager;

using QuickServe.Infrastructure.Identity;
using QuickServe.Infrastructure.Identity.Contexts;
using QuickServe.Infrastructure.Identity.Models;
using QuickServe.Infrastructure.Identity.Seeds;
using QuickServe.Infrastructure.Persistence;
using QuickServe.Infrastructure.Persistence.Contexts;
using QuickServe.Infrastructure.Persistence.Seeds;
using QuickServe.Infrastructure.Resources;
using QuickServe.WebApi.Infrastracture.Extensions;
using QuickServe.WebApi.Infrastracture.Middlewares;
using QuickServe.WebApi.Infrastracture.Services;
using Serilog;
using System.Reflection;
using QuickServe.Infrastructure.FileManager.Contexts;


var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddApplicationLayer();
//builder.Services.AddPersistenceInfrastructure(builder.Configuration);
//builder.Services.AddFileManagerInfrastructure(builder.Configuration);
//builder.Services.AddIdentityInfrastructure(builder.Configuration);
//builder.Services.AddResourcesInfrastructure();

//builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddJwt(builder.Configuration);

#pragma warning disable CS0618 // Type or member is obsolete
//builder.Services.AddControllers().AddFluentValidation(options =>
//{
//    options.ImplicitlyValidateChildProperties = true;
//    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
//});
builder.Services.AddControllers();
#pragma warning restore CS0618 // Type or member is obsolete
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerWithVersioning();
builder.Services.AddCors(x =>
{
    x.AddPolicy("Any", b =>
    {
        b.AllowAnyOrigin();
        b.AllowAnyHeader();
        b.AllowAnyMethod();

    });
});
//builder.Services.AddCustomLocalization(builder.Configuration);

//builder.Services.AddHealthChecks();
//builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
//builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    await services.GetRequiredService<IdentityContext>().Database.MigrateAsync();
//    await services.GetRequiredService<ApplicationDbContext>().Database.MigrateAsync();
//    // await services.GetRequiredService<FileManagerDbContext>().Database.MigrateAsync();

//    //Seed Data
//    await DefaultRoles.SeedAsync(services.GetRequiredService<RoleManager<ApplicationRole>>());
//    await DefaultBasicUser.SeedAsync(services.GetRequiredService<UserManager<ApplicationUser>>());
//    await DefaultData.SeedAsync(services.GetRequiredService<ApplicationDbContext>());
//}

//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuickServe.WebApi v1"));

//app.UseCustomLocalization();
app.UseCors("Any");
//app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
//app.UseSwaggerWithVersioning();
//app.UseMiddleware<ErrorHandlerMiddleware>();
//app.UseHealthChecks("/health");
//app.UseSerilogRequestLogging();

app.MapControllers();

app.Run();
