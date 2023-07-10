namespace Presentation.Transformers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.AspNetCore.Routing;
    using System.Threading.Tasks;

    public class ExampleTransformer : DynamicRouteValueTransformer
    {
        public override ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
        {
            values["controller"] = "Home";
            values["action"] = "Hello";

            return new ValueTask<RouteValueDictionary>(values);
        }
    }
}
