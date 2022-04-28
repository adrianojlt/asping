namespace Asping.Model.Quotes
{
    using Asping.Model;
    using System.Collections.Generic;

    public class Tag
    {
        public Tag()
        {

        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Quote> Quotes { get; set; }

        public List<QuoteTag> QuoteTags { get; set; }
    }
}
