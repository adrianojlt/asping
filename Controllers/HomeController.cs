namespace Asping.Controllers
{
    using Asping.Data;
    using Microsoft.AspNetCore.Mvc;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private AspingDbContext dbContext;

        public HomeController(AspingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult MyView()
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
