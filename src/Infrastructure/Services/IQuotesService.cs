namespace Infrastructure.Services;

using Infrastructure.Model.Quotes;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IQuotesService
{
    public ICollection<Author> GetAllAuthors();

    public Task<Author?> GetAuthorById(int authorId);

    public Task<Author?> CreateAuthor(Author author);

    public Task<Author?> DeleteAuthor(int authorId);

    public ICollection<Quote> GetAllQuotes();

    public ICollection<Tag> GetAllTags();

    public Task<Quote> GetQuoteById(int quoteId);

    public Task<ICollection<Quote>> GetQuoteByAuthorId(int authorId);

    public Task<ICollection<Quote>> GetQuotesFromTagId(int TagId);

    public Task<Quote> CreateQuote(Quote quote);
}
