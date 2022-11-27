namespace Presentation.Extensions;

using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

public static class DbContextExtensions
{
    public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration) 
    {
        services.AddDbContext<AspingDbContext>(options =>
        {
            //options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AspingDb", x => { x.MigrationsAssembly("Presentation"); });
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AspingDb");
        });
    }

    public static void SeedData(this IApplicationBuilder app, IConfiguration conf) 
    {
        using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope()) 
        {
            using (var context = serviceScope.ServiceProvider.GetService<AspingDbContext>())
            {
                context.Database.Migrate();
            }
        }
    }

    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            using (var appContext = scope.ServiceProvider.GetRequiredService<AspingDbContext>())
            {
                try
                {
                    appContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    //Log errors or do anything you think it's needed
                    throw;
                }
            }
        }
        return webApp;
    }
}
