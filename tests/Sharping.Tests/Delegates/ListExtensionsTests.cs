namespace Sharping.Tests.Delegates;

using Sharping.Delegates;

public class ListExtensionsTests
{
    private List<string> names = new List<string>() { "Alice", "john", "Bobby", "Kyle", "Tod", "Armin", "George" };

    [Theory]
    [InlineData(1, 7)]
    [InlineData(3, 6)]
    [InlineData(6, 0)]
    public void Names_In_List_with_More_Than(int nameLength, int expected)
    {
        // Assert
        int result = names.MoreThan(nameLength).Count();

        // Result
        Assert.Equal(result, expected);
    }

    [Theory]
    [InlineData(2, 0)]
    [InlineData(4, 1)]
    [InlineData(5, 3)]
    [InlineData(10, 7)]
    public void Names_In_List_with_Less_Than(int nameLength, int expected)
    {
        // Assert
        int result = names.LessThan(nameLength).Count();

        // Result
        Assert.Equal(result, expected);
    }

    
    [Theory]
    [InlineData(6, 1)]
    public void Names_In_List_With_Exactly(int nameLength, int expected)
    {
        // Assert
        int result = names.Exactly(nameLength).Count();

        // Result
        Assert.Equal(result, expected);
    }

    [Fact]
    public void List_Is_Null()
    {
        // Arrange
        List<string>? emptyList = null;

        // Assert
        int result = emptyList.Exactly(0).Count();

        // Result
        Assert.Equal(0, result);
    }

    [Fact]
    public void List_Is_Empty()
    {
        // Arrange
        List<string> emptyList = Enumerable.Empty<string>().ToList();

        // Assert
        int result = emptyList.Exactly(0).Count();

        // Result
        Assert.Equal(0, result);
    }
}
