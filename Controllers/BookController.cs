using Microsoft.AspNetCore.Mvc;

namespace Asping.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
