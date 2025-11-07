namespace Sharping.Tests.Challengers;

using BenchmarkDotNet.Running;
using Challenges;

public class ArraysTests
{
    [Theory]
    [InlineData(new int[] { 0, 1, 2 }, 0)]
    [InlineData(new int[] { -22, -10, 10, 2 }, 2)]
    [InlineData(new int[] { -200, -22, -11, 100, 20, 30 }, 11)]
    public void Test_Closest_To_Zero_My_Implementation(int[] temperatures, int k)
    {
        var result = Arrays.ComputeClosestToZero(temperatures);

        var summary = BenchmarkRunner.Run<Challenger>();

        Assert.Equal(k, result);
    }

    [Theory]
    [InlineData(new int[] { 1, 4, 3 }, 0)]
    [InlineData(new int[] { 1, 4, 3, 1 }, 1)]
    [InlineData(new int[] { 4, 7, 3, 7, 4, 1, 8 }, 2)]
    [InlineData(new int[] { 4, 7, 3, 7, 4, 1, 8, 4 }, 2)]
    public void Pair_of_socks(int[] socks, int expected)
    {
        var pairs = Arrays.PairOfSocks(socks);

        Assert.Equal(expected, pairs);
    }

    [Theory]
    [InlineData(new int[] {-1, 9, 0, 8, -5, 6}, new int[] {1, 5} )]
    [InlineData(new int[] {-2, -3, 4, -1, -2, 1, 5, -3}, new int[] {2, 6} )]
    [InlineData(new int[] {-2, 1, -3, 4, -1, 2, 1, -5, 4}, new int[] {3, 6} )]
    public void MaxProfitTest(int[] input, int[] expected)
    {
        var result = Arrays.MaxProfit(new List<int>(input));

        Assert.Equal(new List<int>(expected), result);
    }

    [Theory]
    [InlineData(new int[] {1, 5, 8, 1, 2}, 13 , new int[] {1,2})]
    public void FindSumPairTest(int[] input, int sum, int[] expected)
    {
        var result = Arrays.FindSumPair(new List<int>(input), sum);

        Assert.Equal(new List<int>(expected), result);
    }
}