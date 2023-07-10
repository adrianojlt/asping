using Infrastructure.Data;
using Presentation.Extensions;
using Infrastructure.Services;
using GraphQL;
using GraphQL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infrastructure;
using HotChocolate.Types;
using System.IO;
using Microsoft.AspNetCore.Routing;
using Presentation.Transformers;

namespace Presentation;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews().AddNewtonsoftJson(x =>
            {
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

        services.AddMvc( opt =>
        {
            // ... to be able to use UseMvc in Configure Method
            opt.EnableEndpointRouting = false;

            // Add Filters here ...
            // opt.Filters.Add(null);

        });

        //services.AddDatabaseContext(Configuration);

        // ... choose here a real DB or in Memory one.
        var connString = Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext(connString);
        //services.AddDbContext<AspingDbContext>(c => c.UseInMemoryDatabase("Quotes"));

        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = " Asping", Version = "v1" });
        });

        services.AddScoped<IQuotesService, QuotesService>();

        services.AddRazorPages();

        services.AddSingleton<ExampleTransformer>();

        services.AddGraphQLServer()
            .AddQueryType(q => q.Name(OperationTypeNames.Query))
            .AddTypeExtension<Query>()
            .AddTypeExtension<QuotesQuery>()
            .AddType<Instructor>()
            .AddType<Course>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AspingDbContext quotesDbCofalsentext)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Asping Api v1"));
        }

        app.SeedData(Configuration);

        //quotesDbContext.Database.EnsureCreated();


        // Defaults index.html in wwwroot folder.
        // Must be here before UseStaticFiles statment
        app.UseDefaultFiles();

        // Provide static files from wwwroot
        app.UseStaticFiles();

        app.UseRouting();

        app.UseMvc(routes => 
        {
            routes.MapRoute(name: "api", template: "api/{controller}/{action}/{id?}");
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/about", async context =>
            {
                await context.Response.WriteAsync("About Asping info!!!");
            });

            endpoints.MapControllerRoute( 
                name: "default", 
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // ... the previous could also be written like this
            // endpoints.MapDefaultControllerRoute();

            endpoints.MapRazorPages();

            endpoints.MapGraphQL();

            endpoints.MapDynamicControllerRoute<ExampleTransformer>("example/{controller}");
        });
    }
}
