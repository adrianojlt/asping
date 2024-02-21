namespace Sharping.Tests.Delegates;

using Sharping.Delegates;

public class DelegatesTests
{
    [Fact]
    public void PrintStuff_Returns_Correct_String()
    {
        // Arrange
        string name = "Alice";
        int age = 20;

        // Act
        string result = Delegates.PrintStuff(name, age);

        // Assert
        Assert.Equal("Alice@20", result);
    }

    [Fact]
    public void PrintMoreStuff_Returns_Correct_String()
    {
        // Arrange
        string name = "Alice";
        int age = 20;

        // Act
        string result = Delegates.PrintMoreStuff(name, age);

        // Assert
        Assert.Equal("Alice@20", result);
    }

    [Fact]
    public void RemoveAll_OnlyRemovesDot()
    {
        // Arrange
        string address = "admin@admin.com";
        Func<string, string> emailFormatter;
        emailFormatter = Delegates.RemoveAtSign;
        emailFormatter += Delegates.RemoveDots; // last execution will only remove dots

        // Act
        string result = emailFormatter(address);

        // Assert
        Assert.Equal("admin@admincom", result);
    }

    [Fact]
    public void RemoveAll_OnlyRemovesAt()
    {
        // Arrange
        string address = "admin@admin.com";
        Func<string, string> emailFormatter;
        emailFormatter = Delegates.RemoveDots;
        emailFormatter += Delegates.RemoveAtSign; // last execution will only remove AT

        // Act
        string result = emailFormatter(address);

        // Assert
        Assert.Equal("adminadmin.com", result);
    }
}
