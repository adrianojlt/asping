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
}