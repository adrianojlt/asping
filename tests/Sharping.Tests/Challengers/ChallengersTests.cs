using Sharping.Challenges;

namespace Sharping.Tests.Challengers
{
    public class ChallengersTests
    {

        [Theory]
        [InlineData(new int[] { 1,4,3 }, 0)]
        [InlineData(new int[] { 1,4,3,1 }, 1)]
        [InlineData(new int[] { 4, 7, 3, 7, 4, 1, 8 }, 2)]
        [InlineData(new int[] { 4, 7, 3, 7, 4, 1, 8, 4 }, 2)]
        public void Pair_of_socks(int[] socks, int expected)
        { 
            var ch = new Challenger();

            var pairs = ch.PairOfSocks(socks);

            Assert.Equal(expected, pairs);
        }
    }
}
