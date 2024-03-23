namespace Sharping.Challenges
{
    public class Challenger
    {
        public Challenger() 
        { 
        }

        /* 
         * Given an array with numbers, where each number represent a sock color.
         * We want to pair the socks by color and count the number of pairs that 
         * we can made.
         */
        public int PairOfSocks(int[] socks) 
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

        public static bool validateParentheses(string value) 
        {
            if (string.IsNullOrWhiteSpace(value)) 
            {
                return false;
            }

            if (value[0] != '(' && value[^1] != ')') 
            {
                return false;
            }

            var count = 0;

            foreach (char c in value) 
            {
                if (c != '(' && c != ')')
                {
                    return false; 
                }

                if (c != '(') 
                {
                    count++;
                }

                if (c != ')') 
                {
                    count--;
                }
            }

            if (count == 0)
            { 
                return true;
            }

            return false;
        }
    }
}
