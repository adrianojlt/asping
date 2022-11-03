﻿using Asping.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Asping.Extensions
{
    public static class MigrationManager
    {
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

        public static void Cenas(this IServiceCollection services, IApplicationBuilder builder)
        { 
        }
    }
}
