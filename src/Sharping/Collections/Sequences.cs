namespace Sharping.Collections
{
    public class Sequences
    {
        public IEnumerable<int> GetPositiveNumbers(IEnumerable<int> numbers) 
        { 
            foreach (var number in numbers)
            {
                if (number >= 0) 
                { 
                    yield return number;

                    yield return 0;
                    //Console.WriteLine("...");
                }
            }
        }
    }
}
