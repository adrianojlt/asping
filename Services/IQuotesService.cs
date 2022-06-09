namespace Asping.Services
{
    using Asping.Model.Quotes;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IQuotesService
    {

        public ICollection<Quote> GetAllQuotes();

        public ICollection<Author> GetAllAuthors();

        public ICollection<Tag> GetAllTags();

        public Task<Author> GetAuthorById(int authorId);

        public Task<Quote> GetQuoteById(int quoteId);

        public Task<ICollection<Quote>> GetQuoteByAuthorId(int authorId);

        public Task<ICollection<Quote>> GetQuotesFromTagId(int TagId);

        public Task<Quote> CreateQuote(Quote quote);
    }
}
