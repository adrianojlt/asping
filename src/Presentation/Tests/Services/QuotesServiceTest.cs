namespace Presentation.Tests.Services;

using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System;
using Infrastructure.Model.Quotes;

public class QuotesServiceTest
{
    private IQuotesService service;

    public QuotesServiceTest()
    {
        var options = new DbContextOptionsBuilder<AspingDbContext>()
         .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
         .Options;

        var dbContext = new AspingDbContext(options);

        this.service = new QuotesService(dbContext);

        dbContext.Database.EnsureCreated();
    }
    [Fact]
    public async void CreateAuthor_ValidId_ShouldReturnCreatedEntity()
    {
        var author = new Author() { Name = "John" };

        var created = await this.service.CreateAuthor(author);

        Assert.IsNotNull(created);
    }

    [Fact]
    public async void GetQuoteByAuthorId_ValidId_ShouldReturnValidQuotes()
    {
        var authorId = 2;
        var result = await service.GetQuoteByAuthorId(authorId);

        var expected = SeedQuotes.Quotes.Where(q => q.AuthorId == authorId);

        Assert.IsNotNull(result);
        Assert.AreEqual(result.Count(), expected.Count());
    }

    [Fact]
    public async void GetQuotesFromTag_ExistingTag_ShoudReturnValidQuotes()
    {
        var tagId = 1;

        var quotes = await service.GetQuotesFromTagId(tagId);

        var quoteIds = SeedQuotes.QuotesTags
            .Where(qt => qt.TagId == tagId)
            .Select(s => s.QuoteId);

        var expected = SeedQuotes.Quotes.Where(q => quoteIds.Contains(q.Id));

        Assert.IsNotNull(quotes);
        Assert.IsTrue(quotes.Any());
        Assert.AreEqual(quotes.Count, expected.Count());
    }

    public async void TestWithMocks()
    {
        var mockSetAuthor = GetMockDbSet(SeedQuotes.Authors.AsQueryable());

        var mockQuoteSet = GetMockDbSet(SeedQuotes.Quotes.AsQueryable());

        mockQuoteSet.Setup(x => x.Include("Author")).Returns(mockQuoteSet.Object);

        var mockContext = new Mock<AspingDbContext>();

        //mockContext.Setup(x => x.Authors).Returns(mockSetAuthor.Object);
        mockContext.Setup(x => x.Quotes).Returns(mockQuoteSet.Object);

        service = new QuotesService(mockContext.Object);

        var quotesres = service.GetAllQuotes();

        var quotesByAuthorId = await service.GetQuoteByAuthorId(2);

        Assert.IsNotNull(quotesres);
    }

    private Mock<DbSet<T>> GetMockDbSet<T>(IQueryable<T> entities) where T : class
    {
        var mockSet = new Mock<DbSet<T>>();

        mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(entities.Provider);
        mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(entities.Expression);
        mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(entities.ElementType);
        mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());

        return mockSet;
    }
}
