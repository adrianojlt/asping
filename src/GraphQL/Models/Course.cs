namespace GraphQL.Models
{
    public class Course : ISearchResultType
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public Subject Subject { get; set; }

        [GraphQLNonNullType]
        public Instructor? Instructor { get; set; }

        public IEnumerable<Student>? Students { get; set; }
    }
}
