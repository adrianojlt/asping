namespace Sharping.Challenges;

public class Arrays
{
    /*
     * Given an array with numbers, where each number represent a sock color.
     * We want to pair the socks by color and count the number of pairs that
     * we can made.
     */
    public static int PairOfSocks(int[] socks)
    {
        var pairs = new Dictionary<int, int>();

        var total = 0;

        if (socks.Length < 2)
        {
            return 0;
        }

        foreach (int sock in socks)
        {
            pairs[sock] = pairs.ContainsKey(sock) ? pairs[sock] + 1 : 1;
        }

        foreach (var p in pairs)
        {
            total += p.Value / 2;
        }

        return total;
    }

    public static bool Exists(int[] ints, int k)
    {
        Array.BinarySearch(ints, k);

        return false;
    }

    public static int ComputeClosestToZero(int[] temperatures)
    {
        if (temperatures.Length == 0)
        {
            return 0;
        }

        var closest = 200;

        for (var t = 0; t <= closest; t++)
        {
            if (temperatures.Contains(t) || temperatures.Contains(-t))
            {
                return Math.Abs(t);
            }
        }

        return 0;
    }
}