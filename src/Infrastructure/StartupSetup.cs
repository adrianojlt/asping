namespace Infrastructure;

using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class StartupSetup
{
    public static void AddDbContext(this IServiceCollection services, string connectionString) =>
        services.AddDbContext<AspingDbContext>(
            options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Presentation")));
}
