namespace asping.Model
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

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime When { get; set; }

        public int? AuthorId { get; set; }

        public Author Author { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
