namespace Asping.Model.Quotes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Quote
    {
        public Quote()
        {
            this.CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public string Value { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime When { get; set; }

        public int? AuthorId { get; set; }

        public Author Author { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public List<QuoteTag> QuoteTags { get; set; }
    }
}
