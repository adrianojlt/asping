using Asping.Model.Quotes;
using System.Collections.Generic;
using System.Linq;

namespace Asping.Data
{
    public static class SeedQuotes
    {
        public static IEnumerable<Tag> Tags { get; } = new List<Tag>() 
        {
            new Tag() { Id = 1, Name = "General",   Description = "General" },
            new Tag() { Id = 2, Name = "Science",   Description = "Science" },
            new Tag() { Id = 3, Name = "Business",  Description = "Business" },
            new Tag() { Id = 4, Name = "Life",      Description = "Life" },
            new Tag() { Id = 5, Name = "History",   Description = "History" }
        };

        public static IEnumerable<Author> Authors { get; } = new List<Author>()
        {
            new Author() { Id = 1, Name = "Albert Einstein" },
            new Author() { Id = 2, Name = "Abraham Lincoln" }
        };

        public static IEnumerable<Quote> Quotes { get; } = new List<Quote>() 
        {
              new Quote() { Id = 1, AuthorId = 2, When = new System.DateTime(1838, 1, 1), Value = "America will never be destroyed from the outside" },
              new Quote() { Id = 2, AuthorId = 1, Value = "Two things are infinite: the universe and human stupidity; and I'm not sure about the universe." }
        };

        public static IEnumerable<QuoteTag> QuotesTags { get; } = new List<QuoteTag>()
        { 
            new QuoteTag() { QuoteId = 1, TagId = 1},
            new QuoteTag() { QuoteId = 1, TagId = 5},
            new QuoteTag() { QuoteId = 2, TagId = 1},
            new QuoteTag() { QuoteId = 2, TagId = 2}
        };
    }
}
