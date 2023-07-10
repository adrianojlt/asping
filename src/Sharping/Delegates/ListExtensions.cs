namespace Sharping.Delegates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ListExtensions
    {
        private delegate bool Filter(string name);

        public static IEnumerable<string> Exactly(this IEnumerable<string> names, int nameLength)
        {
            return ExtractStrings(names.ToArray(), name => name.Length == nameLength);
        }

        public static IEnumerable<string> LessThan(this IEnumerable<string> names, int nameLength)
        {
            return ExtractStrings(names.ToArray(), name => name.Length < nameLength);
        }

        public static IEnumerable<string> MoreThan(this IEnumerable<string> names, int nameLength)
        {
            return ExtractStringsFunc(names.ToArray(), name => name.Length > nameLength);
        }

        private static IEnumerable<string> ExtractStrings(string[] names, Filter filter)
        {
            List<string> result = Enumerable.Empty<string>().ToList();

            if (names == null || !names.Any())
            {
                return result;
            }

            foreach (string name in names)
            {
                if (filter(name))
                {
                    result.Add(name);
                }
            }

            return result;
        }

        // The same as above but without the need to declare the "private delegate bool Filter"
        private static IEnumerable<string> ExtractStringsFunc(string[] names, Func<string, bool> filter)
        {
            List<string> result = Enumerable.Empty<string>().ToList();

            if (names == null || !names.Any())
            {
                return result;
            }

            foreach (string name in names)
            {
                if (filter(name))
                {
                    result.Add(name);
                }
            }

            return result;
        }
    }
}
