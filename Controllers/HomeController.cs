namespace Asping.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
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
    }
}
