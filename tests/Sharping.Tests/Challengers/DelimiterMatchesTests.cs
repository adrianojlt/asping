namespace Sharping.Tests.Challengers;

using Challenges;

public class DelimiterMatchesTests
{
    [Theory]
    [InlineData(null, false)]
    [InlineData("", false)]
    [InlineData(")(", false)]
    [InlineData("()", true)]
    [InlineData("((()))", true)]
    [InlineData("((()()))", true)]
    [InlineData("(()((()))()))", false)]
    [InlineData("(()", false)]
    public void ValidateParenthesis(string value, bool expected)
    {
        var result = DelimiterMatches.ValidateParenthesis(value);

        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData("([()])", true)]
    [InlineData("([](())())", true)]
    [InlineData("([](()())())", true)]
    [InlineData("()()()", true)]
    [InlineData("()[]()", true)]
    [InlineData("()][()", false)]
    [InlineData("(][)()", false)]
    public void CheckMatching(string? value, bool expected)
    {
        var a = DelimiterMatches.CheckMatchingOriginal(value);
        var b = DelimiterMatches.CheckMatching(value);

        Assert.Equal(expected, a);
        Assert.Equal(expected, b);
    }

    [Theory]
    [InlineData("{{{}}}", true)]
    [InlineData("{{}{{}{}}{}}", true)]
    [InlineData("{}{}{}", true)]
    [InlineData("{}}{{}", false)]
    [InlineData("}{", false)]
    public void CheckMatchingCurlyBraces(string value, bool expected)
    {
        var openingChars = new char[] { '(', '[', '<', '{' };
        var closingChars = new char[] { ')', ']', '>', '}' };

        var result = DelimiterMatches.CheckMatching(value, openingChars, closingChars);

        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData("[[[]]]", true)]
    [InlineData("[[][[][]][]]", true)]
    [InlineData("[][][]", true)]
    [InlineData("[]][[]", false)]
    [InlineData("][", false)]
    public void CheckMatchingBrackets(string value, bool expected)
    {
        var openingChars = new char[] { '(', '[', '<', '{' };
        var closingChars = new char[] { ')', ']', '>', '}' };

        var result = DelimiterMatches.CheckMatching(value, openingChars, closingChars);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("([()])", true)]
    [InlineData("([](())())", true)]
    [InlineData("({}(()<>)[])", true)]
    [InlineData("()[]<>{}", true)]
    [InlineData("<>[]<>", true)]
    [InlineData("()><()", false)]
    [InlineData("(][)()", false)]
    public void CheckMatchingAll(string value, bool expected)
    {
        var openingChars = new char[] { '(', '[', '<', '{' };
        var closingChars = new char[] { ')', ']', '>', '}' };

        var result = DelimiterMatches.CheckMatching(value, openingChars, closingChars);

        Assert.Equal(expected, result);
    }
}