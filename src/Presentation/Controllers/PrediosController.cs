namespace Presentation.Controllers;

using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PrediosController : Controller
{
    private readonly AspingDbContext dbContext;

    public PrediosController(AspingDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var predios = dbContext.Predio.Include(c => c.Freguesia.Concelho.Distrito);

        return Ok(predios);
    }
}
