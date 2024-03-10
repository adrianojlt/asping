namespace Presentation.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public class CustomHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomHeaderMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Add("X-Custom-Header", "Hello from custom middleware");

            await _next(context);
        }
    }
}
