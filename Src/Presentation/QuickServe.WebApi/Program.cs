using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuickServe.Application;
using QuickServe.Application.Interfaces;
using QuickServe.Infrastructure.FileManager;

using QuickServe.Infrastructure.Identity;
using QuickServe.Infrastructure.Identity.Contexts;
using QuickServe.Infrastructure.Persistence;
using QuickServe.Infrastructure.Resources;
using QuickServe.WebApi.Infrastracture.Extensions;
using QuickServe.WebApi.Infrastracture.Middlewares;
using QuickServe.WebApi.Infrastracture.Services;
using Serilog;
using System.Reflection;
using Microsoft.AspNetCore.Routing;
using QuickServe.Infrastructure.Identity.Models;
using Microsoft.EntityFrameworkCore;
using QuickServe.Infrastructure.Identity.Seeds;
using QuickServe.Infrastructure.Persistence.Contexts;
using QuickServe.Application.Interfaces.IngredientInterfaces;
using QuickServe.Infrastructure.Persistence.Services;
using QuickServe.Infrastructure.FileManager.Services;
using QuickServe.Application.Interfaces.ImageInterfaces;
using QuickServe.Application.Interfaces.IProductTemplateServices;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddFileManagerInfrastructure(builder.Configuration);
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddResourcesInfrastructure();

builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IProductTemplateService,  ProductTemplateService>();
builder.Services.AddDistributedMemoryCache();

#pragma warning disable CS0618 // Type or member is obsolete
builder.Services.AddControllers().AddFluentValidation(options =>
{
    options.ImplicitlyValidateChildProperties = true;
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});
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
builder.Services.AddCustomLocalization(builder.Configuration);

//builder.Services.AddHealthChecks();
builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddJwt(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuickServe.WebApi v1");
    c.RoutePrefix = string.Empty;
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    await services.GetRequiredService<AppIdentityContext>().Database.MigrateAsync();

    //Seed Data
    await DefaultRoles.SeedAsync(services.GetRequiredService<RoleManager<ApplicationRole>>());
    await DefaultBasicUser.SeedAsync(services.GetRequiredService<UserManager<ApplicationUser>>());
}

app.UseCustomLocalization();
app.UseCors("Any");
//app.UseRouting();
app.UseHttpsRedirection();
//app.UseAuthentication();
//app.UseAuthorization();
app.UseSwaggerWithVersioning();
app.UseMiddleware<ErrorHandlerMiddleware>();
//app.UseHealthChecks("/health");
app.UseSerilogRequestLogging();

app.MapControllers();

app.Run();
