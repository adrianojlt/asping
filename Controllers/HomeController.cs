namespace Asping.Controllers
{
    using Asping.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

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
            var predios = dbContext.Predio.Include(c => c.Freguesia.Concelho.Distrito);



            return Ok();
        }

    }
}
