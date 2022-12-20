namespace GraphQL;

using Bogus;
using GraphQL.Models;

[ExtendObjectType(OperationTypeNames.Query)]
[GraphQLName(nameof(Query))]
public class Query
{
    private readonly Faker<Instructor> instructorsFaker;
    private readonly Faker<Student> studentsFaker;
    private readonly Faker<Course> coursesFaker;

    public Query()
    {
        this.instructorsFaker = new Faker<Instructor>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.Salary, f => f.Random.Double(0, 100000));

        this.studentsFaker = new Faker<Student>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.GPA, f => f.Random.Double(1, 4));

        this.coursesFaker = new Faker<Course>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Name.JobTitle())
            .RuleFor(c => c.Subject, f => f.PickRandom<Subject>())
            .RuleFor(c => c.Instructor, f => this.instructorsFaker.Generate())
            .RuleFor(c => c.Students, f => this.studentsFaker.Generate(5));
    }

    public IEnumerable<Course> GetCourses()
    {
        return this.coursesFaker.Generate(5);
    }

    public async Task<IEnumerable<ISearchResultType>> Search(string term) 
    {
        return null;
    }

    [GraphQLDeprecated("This Query is deprecated")]
    public string Instructions => "GraphQL Tutorial!!!";
}