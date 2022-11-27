namespace GraphQL;

using Infrastructure.Model.Quotes;
using Infrastructure.Services;


[ExtendObjectType(OperationTypeNames.Query)]
[GraphQLName(nameof(QuotesQuery))]
public class QuotesQuery
{
    public ICollection<Quote> GetQuotes([Service] IQuotesService quotesService) 
    {
        return quotesService.GetAllQuotes();
    }

    public ICollection<Author> GetAuthors([Service] IQuotesService quotesService)
    {
        return quotesService.GetAllAuthors();
    }

    public ICollection<Tag> GetTags([Service] IQuotesService quotesService) { 

        return quotesService.GetAllTags();
    }
}
