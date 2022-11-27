namespace GraphQL.Models
{
    public class Instructor : ISearchResultType
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public double Salary { get; set; }
    }
}
