using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Presentation.Middlewares
{
    public class RedirectMiddleware
    {
        private readonly RequestDelegate _next;

        public RedirectMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context) 
        {
            if (context.Request.Path.StartsWithSegments("/lnk")) 
            {
                context.Response.Redirect("/Home/Dynamic");

                return;
            }

            await _next(context);
        }
    }
}
