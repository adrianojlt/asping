namespace Asping.Controllers
{
    using Asping.Model.Quotes;
    using Asping.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private IQuotesService quotesService;

        public QuotesController(IQuotesService quotesService)
        {
            this.quotesService = quotesService;
        }

        // GET /api/quotes
        [HttpGet]
        public IActionResult Get()
        {
            var quotes = this.quotesService.GetAllQuotes();

            return Ok(quotes);
        }

        // GET /api/quotes/3
        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> Get(int id)
        {
            var quote = await this.quotesService.GetQuoteById(id);

            return Ok(quote);
        }

        // GET /api/quotes/tags
        [HttpGet]
        [Route("tags")]
        public IActionResult GetTags()
        {
            var tags = this.quotesService.GetAllTags();

            return Ok(tags);
        }

        // GET /api/quotes/tag/3/quotes
        [HttpGet]
        [Route("tag/{tagId?}/quotes")]
        public IActionResult GetQuotesTags(int tagId)
        {
            var quotes = this.quotesService.GetQuotesFromTagId(tagId);

            return Ok(quotes);
        }

        // POST /api/quotes/author/3/quotes
        [HttpPost]
        [Route("author/{authorId?}/quotes")]
        public async Task<IActionResult> CreateQuote(int authorId, [FromBody] Quote quote)
        {

            // Validate sent data through data annotations 
            if (!ModelState.IsValid)
            {
                return BadRequest("Quote has invalid data");
            }

            var author = await this.quotesService.GetAuthorById(authorId);

            if (author == null)
            {
                return BadRequest("No Author Found");
            }

            quote.AuthorId = authorId;

            var savedQuote = await this.quotesService.CreateQuote(quote);

            return CreatedAtAction("Quote", new { authorId = authorId, id = savedQuote.Id }, savedQuote);
        }

        [HttpGet]
        [Route("author")]
        public IActionResult GetAuthor(int authorId)
        {
            var authors = this.quotesService.GetAllAuthors();

            return Ok(authors);
        }

        [HttpPost]
        [Route("author")]
        public IActionResult CreateAuthor([FromBody] Author author)
        {
            return null;
        }
    }
}
