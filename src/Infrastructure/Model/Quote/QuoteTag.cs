﻿namespace Infrastructure.Model.Quotes;

using Infrastructure.Model.Quotes;

public class QuoteTag
{
    public int QuoteId { get; set; }
    public Quote? Quote { get; set; }

    public int TagId { get; set; }
    public Tag? Tag { get; set; }
}
