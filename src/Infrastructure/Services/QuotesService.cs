namespace Infrastructure.Services;

using Infrastructure.Data;
using Infrastructure.Model.Quotes;
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
        return this.dbContext?.Authors?.ToList() ?? new List<Author>();
    }

    public async Task<Author?> GetAuthorById(int authorId)
    {
        if (this.dbContext?.Authors == null) return default;

        var author = await this.dbContext.Authors.FindAsync(authorId);

        return author;
    }

    public async Task<Author?> CreateAuthor(Author author) 
    {
        if (this.dbContext?.Authors == null) return default;

        var saved = this.dbContext.Authors.Add(author);

        await this.dbContext.SaveChangesAsync();

        return new Author() 
        { 
            Id = saved.Entity.Id, 
            Name = saved.Entity.Name,   
            Birthday = saved.Entity.Birthday,
            Death = saved.Entity.Death
        };
    }

    public async Task<Author?> DeleteAuthor(int authorId) 
    {
        if (this.dbContext?.Authors == null) return default;

        var result = await dbContext.Authors.FirstOrDefaultAsync(a => a.Id == authorId);

        if (result == null) 
        {
            return default;
        }

        this.dbContext.Authors.Remove(result);
        await this.dbContext.SaveChangesAsync();

        return result;
    }

    public ICollection<Quote> GetAllQuotes()
    {
        if (this.dbContext?.Quotes == null) return new List<Quote>();

        return this.dbContext.Quotes.Include(q => q.Author).ToList();
    }

    public ICollection<Tag> GetAllTags()
    {
        if (this.dbContext?.Tags == null) return new List<Tag>();

        return this.dbContext.Tags.Include(qt => qt.QuoteTags).ThenInclude(q => q.Quote).ToList();
    }


    public async Task<Quote> GetQuoteById(int quoteId)
    {
        if (this.dbContext?.Quotes == null) return new Quote();

        var quote = await this.dbContext.Quotes.FindAsync(quoteId);

        return quote ?? new Quote();
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
