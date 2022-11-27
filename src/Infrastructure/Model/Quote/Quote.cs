namespace Infrastructure.Model.Quotes;

using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Quote
{
    public Quote()
    {
        this.CreatedAt = DateTime.Now;
    }

    [GraphQLType(typeof(NonNullType<IdType>))]
    public int Id { get; set; }

    [Required]
    public string? Value { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? When { get; set; }

    public int? AuthorId { get; set; }

    public Author? Author { get; set; }

    public ICollection<Tag>? Tags { get; set; }

    public List<QuoteTag>? QuoteTags { get; set; }
}
