namespace Presentation.Middlewares;

using Microsoft.AspNetCore.Rewrite;

public class ExampleRule : IRule
{
    public void ApplyRule(RewriteContext context)
    {
        var url = context.HttpContext.Request.Path.Value;

        return;
    }
}
