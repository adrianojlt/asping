namespace Asping.Services
{
    using Asping.Data;
    using Asping.Model.Quotes;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class QuotesService : IQuotesService
    {

        private AspingDbContext dbContext; 

        public QuotesService(AspingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<Author> GetAllAuthors()
        {
            return this.dbContext.Authors.ToList();
        }

        public ICollection<Quote> GetAllQuotes()
        {
            return this.dbContext.Quotes.ToList();
        }

        public ICollection<Tag> GetAllTags()
        {
            return this.dbContext.Tags.ToList();
        }

        public async Task<Author> GetAuthorById(int authorId)
        {
            return await this.dbContext.Authors.FindAsync(authorId);
        }

        public async Task<Quote> GetQuoteById(int quoteId)
        {
            return await this.dbContext.Quotes.FindAsync(quoteId);
        }

        public async Task<ICollection<Quote>> GetQuoteByAuthorId(int authorId)
        {
            var quotes = await this.dbContext.Quotes
                .Include(x => x.Author)
                .Where(x => x.AuthorId == authorId)
                .ToListAsync();

            return quotes;
        }

        public async Task<ICollection<Quote>> GetQuotesFromTagId(int TagId)
        {
            return await this.dbContext.Quotes
                .Include(x => x.QuoteTags.Where(y => y.TagId == TagId))
                .ToListAsync();
        }

        public async Task<Quote> CreateQuote(Quote quote)
        {
            var savedQuote = await this.dbContext.Quotes.AddAsync(quote);

            await this.dbContext.SaveChangesAsync();

            return savedQuote.Entity;
        }
    }
}
