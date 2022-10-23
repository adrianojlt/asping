namespace Asping.Controllers.api
{
    using Asping.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    [ApiController]
    [Route("api/[controller]")]
    public class LocalController : ControllerBase
    {
        private AspingDbContext dbContext; 

        public LocalController(AspingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Get()
        {
            var locals = this.dbContext.Distrito
                .Include(d => d.Concelhos)
                .ThenInclude(c => c.Freguesias)
                .ToList();

            return Ok(locals);
        }

        [HttpGet]
        [Route("distritos")]
        public IActionResult GetDistritos()
        {
            var result = this.dbContext.Distrito.ToList();

            return Ok(result);
        }

        [HttpGet]
        [Route("concelhos/{distritoId?}")]
        public IActionResult GetConcelhos(int distritoId)
        {
            var result = dbContext.Concelho.Where(c => c.DistritoId == distritoId).ToList();

            return Ok(result);
        }

        [HttpGet]
        [Route("freguesias/{concelhoId?}")]
        public IActionResult GetFreguesias(int concelhoId)
        {
            var result = dbContext.Freguesia.Where(f => f.ConcelhoId == concelhoId).ToList();

            return Ok(result);
        }
    }
}
