namespace Presentation.Controllers
{
    using Infrastructure.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.AspNetCore.Routing;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private AspingDbContext dbContext;

        private readonly IUrlHelperFactory urlHelperFactory;

        private readonly IEndpointRouteBuilder endpointRouteBuilder;

        public HomeController(
            AspingDbContext dbContext, 
            IUrlHelperFactory urlHelperFactory)
        {
            this.dbContext = dbContext;
            this.urlHelperFactory = urlHelperFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult MyView()
        {
            return View();
        }

        public ActionResult Routing()
        {
            return View();
        }

        public IActionResult About()
        {
            return base.Content("<html><h1>About</h1></html>", "text/html");
        }

        public IActionResult Hello()
        {
            return Ok("Helllloooooo Uncle Leo!!!");
        }

        public IActionResult Predios()
        {
            return Ok();
        }

        public IActionResult AddRoute(string route, string name) 
        {
            // add routes to db here ...
            return Ok();
        }

        public IActionResult ProcessRoute() 
        { 
            return Ok("Route Processed!!!!"); 
        }

        public IActionResult Dynamic() 
        {
            var request = this.HttpContext.Request;

            return Redirect("https://www.google.com");
        }

        public IActionResult Error()
        {
            return StatusCode(500, "custom 500 error!!!");
        }

        public async Task<IActionResult> Temp()
        {
            var client = new HttpClient();

            var host = HttpContext.Request.Host.ToUriComponent();

            var pathBase = HttpContext.Request.PathBase.ToUriComponent();

            var url = $"{HttpContext.Request.Scheme}://{host}{pathBase}";

            var result = await client.GetAsync($"{url}/Home/Error");

            var message = await result.Content.ReadAsStringAsync();

            return base.Content($"<html><body>Status Code: {result.StatusCode}; Response Message: {message}</body></html>", "text/html");
        }
    }
}
