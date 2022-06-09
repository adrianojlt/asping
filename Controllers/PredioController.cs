namespace Asping.Controllers
{
    using Asping.Data;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class PredioController : Controller
    {
        private AspingDbContext dbContext;

        public IActionResult Index()
        {

            return View();
        }
    }
}
