using Microsoft.AspNetCore.Mvc;

namespace Asping.Controllers
{
    public class PhisController : Controller
    {
        public IActionResult Index()
        {
            //return View("~/Views/Phis/Pages/Basic/index.cshtml");
            return View("~/Views/Phis/Pages/Simple/index.cshtml");
        }

        public IActionResult BackOffice()
        {
            return View();
        }
    }
}
