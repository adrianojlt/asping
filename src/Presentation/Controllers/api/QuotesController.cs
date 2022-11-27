namespace Presentation.Controllers
{
    using Infrastructure.Data;
    using Infrastructure.Model.Quotes;
    using Infrastructure.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        // GET /api/quotes/authors
        [HttpGet]
        [Route("authors")]
        public IActionResult GetAuthors() 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Author has invalid data");
            }

            var authors = this.quotesService.GetAllAuthors();

            return Ok(authors);
        }

        // POST /api/quotes/authors
        [HttpPost]
        [Route("author")]
        public async Task<ActionResult<Author>> CreateAuthor(Author autor)
        {
            var created = await this.quotesService.CreateAuthor(autor);

            return Ok(created);
        }

        // DEL /api/quotes/author
        [HttpDelete]
        [Route("author/{authorId?}")]
        public async Task<ActionResult<Author>> DeleteAuthors(int authorId)
        {
            try
            {
                var authorToDelete = await this.quotesService.GetAuthorById(authorId);

                if (authorToDelete == null)
                {
                    return NotFound();
                }

                var deleted = this.quotesService.DeleteAuthor(authorId);

                return Ok(deleted);
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
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

            if (quote.Tags == null || !quote.Tags.Any() ) {
                quote.Tags = new List<Tag>() { new Tag() { Id = SeedQuotes.Tags.First().Id } };
            }

            quote.AuthorId = authorId;

            var savedQuote = await this.quotesService.CreateQuote(quote);

            return CreatedAtAction("Quote", new { authorId = authorId, id = savedQuote.Id }, savedQuote);
        }
    }
}
