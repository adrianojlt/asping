using Sharping.Challenges;
using Xunit.Abstractions;

namespace Sharping.Tests.Challengers
{
    public class ChallengersTests
    {
        private readonly ITestOutputHelper output;

        public ChallengersTests(ITestOutputHelper output)
        {
            this.output = output;
        }



        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData(")(", false)]
        [InlineData("()", true)]
        [InlineData("((()))", true)]
        [InlineData("((()()))", true)]
        [InlineData("(()((()))()))", false)]
        [InlineData("(()", false)]
        public void Validate_pharentheses(string value, bool expected) 
        { 
            var result = DelimiterMatches.ValidateParenthesis(value);

            Assert.Equal(expected, result);
        }


    }
}
