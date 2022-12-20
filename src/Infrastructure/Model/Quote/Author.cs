namespace Infrastructure.Model.Quotes;

using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Author
{
    public Author() 
    { 
        this.Name = string.Empty;
    }
    [GraphQLType(typeof(NonNullType<IdType>))]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string? Birthday { get; set; }

    public string? Death { get; set; }

    public List<Quote>? Quotes { get; set; }
}
