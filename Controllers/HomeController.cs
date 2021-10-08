namespace asping.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : ControllerBase
    {

        public IActionResult Index()
        {
            return base.Content("<html><h1>Index</h1></html>", "text/html");
        }

        public IActionResult Hello()
        {
            return Ok("Helllloooooo Uncle Leo!!!");
        }
    }
}
