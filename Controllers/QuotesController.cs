namespace asping.Controllers
{
    using asping.Data;
    using asping.Model;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private AspingDbContext dbContext; 

        public QuotesController(AspingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var quotes = this.dbContext.Quotes;

            return Ok(quotes);
        }

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> Get(int id)
        {
            var quote = await this.dbContext.Quotes.FindAsync(id);

            return Ok(quote);
        }

        [HttpPost]
        public IActionResult Create(int authorId, [FromBody] Quote quote)
        {
            if (quote == null)
            {
                return BadRequest("quote is null");
            }

            var author = this.dbContext.Find<Author>(authorId);

            if (author == null)
            {
                return BadRequest("no author");
            }

            quote.AuthorId = authorId;

            var quoteToReturn = this.dbContext.Quotes.Add(quote);
            this.dbContext.SaveChanges();

            return CreatedAtAction("Quote", new { authorId = authorId, id = quoteToReturn.Entity.Id }, quoteToReturn);
        }
    }
}
