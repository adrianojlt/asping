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

    /**
     * Given an array of integers representing the monthly net profits
     * returns the range of consecutive months that had the most profit
     * Kadane's Algorithm
     */
    public static List<int> MaxProfit(List<int>? data)
    {
        if (data == null || data.Count == 0)
        {
            return new List<int>() { 0, 0 };
        }

        int maxSum = data[0];
        int maxSubSum = data[0];
        int start = 0;
        int end = 0;
        int temp = 0;

        for (int i = 1; i < data.Count; i++)
        {
            if (maxSubSum < 0)
            {
                maxSubSum = data[i];
                temp = i;
            }
            else
            {
                maxSubSum += data[i];
            }

            if (maxSubSum > maxSum)
            {
                maxSum = maxSubSum;
                start = temp;
                end = i;
            }
        }

        return new List<int>() { start, end };
    }

    public static List<int> FindSumPair(List<int> numbers, int k) {

        Dictionary<int, int> dict = new Dictionary<int, int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            int temp = k - numbers[i];

            if (dict.ContainsKey(temp))
            {
                int tempIndex = dict[temp];

                if (tempIndex < i)
                {
                    return new List<int>() { tempIndex, i };
                }

                return new List<int>() { i, tempIndex };
            }

            if (!dict.ContainsKey(numbers[i]))
            {
                dict[numbers[i]] = i;
            }
        }

        return new List<int>() { 0, 0 };
    }
}