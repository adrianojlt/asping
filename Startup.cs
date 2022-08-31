using Asping.Data;
using Asping.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Asping
{
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

            //services.AddDbContext<QuotesDbContext>(c => c.UseInMemoryDatabase("Quotes")) >

            var connString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AspingDbContext>(option => option.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AspingDb"));
            //services.AddDbContext<AspingDbContext>(opt => opt.use)

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = " Asping", Version = "v1" });
            });

            services.AddScoped<IQuotesService, QuotesService>();

            services.AddRazorPages();

            // In Prod the React files will be served from this directory
            services.AddSpaStaticFiles(config => 
            { 
                config.RootPath = "ClientApp/build"; 
            });
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

            //quotesDbContext.Database.EnsureCreated();

            // Provide static files from wwwroot
            app.UseStaticFiles();

            // For React files (must be after UseStaticFiles)
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseMvc(routes => 
            {
                routes.MapRoute(name: "api", template: "api/{controller}/{action}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/about", async context =>
                {
                    await context.Response.WriteAsync("About me info!!!");
                });

                endpoints.MapControllerRoute( 
                    name: "default", 
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // ... the previous could also be written like this
                // endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });

            // Must be after UseEndpoints, otherwise React will take over routing and MVC routes wont work
            app.UseSpa(config => 
            {
                config.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    config.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
