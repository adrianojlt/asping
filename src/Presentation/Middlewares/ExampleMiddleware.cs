namespace Presentation.Middlewares;

using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class ExampleMiddleware
{
    private readonly RequestDelegate _next;

    public ExampleMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);
    }
}
