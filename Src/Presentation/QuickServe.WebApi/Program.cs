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


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddFileManagerInfrastructure(builder.Configuration);
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddResourcesInfrastructure();

builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
builder.Services.AddDistributedMemoryCache();
//builder.Services.AddJwt(builder.Configuration);

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

builder.Services.AddAuthentication(o =>
{
    o.DefaultScheme = IdentityConstants.ApplicationScheme;
})
    .AddCookie(IdentityConstants.ApplicationScheme)
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityContext>()
    .AddApiEndpoints();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapGroup("api/v1/identity").MapIdentityApi<IdentityUser>();

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

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//app.UseSwagger();
//app.UseSwaggerUI(c => {
//    c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuickServe.WebApi v1");
//    c.RoutePrefix = string.Empty;
//});

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "Customer", "Staff", "Store_Manager", "Brand_Manager" };
    foreach (var role in roles)
    {
        if (!roleManager.RoleExistsAsync(role).Result)
        {
            await roleManager.CreateAsync(new IdentityRole { Name = role });
        }
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    string email = "sysadmin@quickserve.com";
    string password = "Admin@123";
    var user = await userManager.FindByEmailAsync(email);
    if (user == null)
    {
        user = new IdentityUser
        {
            UserName = email,
            Email = email
        };
        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Admin");
    }
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
