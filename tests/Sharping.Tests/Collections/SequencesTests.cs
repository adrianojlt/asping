using Sharping.Collections;

namespace Sharping.Tests.Collections
{
    public class SequencesTests
    {

        [Fact]
        public void Test_Yield_Example() 
        {
            var sequences = new Sequences();

            var result = sequences.GetPositiveNumbers(new List<int> { 1, -2, -4, 5, 9 });

            Assert.True(result.Any());
            Assert.Equal(3, result.Count(x => x == 0));
            Assert.Equal(6, result.Count());
        } 
    }
}
