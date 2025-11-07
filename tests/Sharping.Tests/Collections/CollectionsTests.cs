namespace Sharping.Tests.Collections;

using Sharping.Collections;

public class CollectionsTests
{
    private readonly Dictionary<String, Account> _accounts = new Dictionary<string, Account>()
    {
        { "0001", new Account() { Id = "0001", Amount = 100 } },
        { "0003", new Account() { Id = "0003", Amount = 200 } },
        { "0004", new Account() { Id = "0004", Amount = 2200 } }
    };

    [Fact]
    public void Dictionary_To_List()
    {
        // Arrange
        var coll = new Collections();
        var expected = new List<string>() { "0004(2200)", "0003(200)", "0001(100)" };

        // Act
        var result = coll.ToListOrdered(_accounts);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(result, expected);
    }
}