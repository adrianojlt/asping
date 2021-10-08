namespace asping.Model
{
    using System.Collections.Generic;

    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Birthday { get; set; }

        public string Death { get; set; }

        public List<Quote> Quotes { get; set; }
    }
}
