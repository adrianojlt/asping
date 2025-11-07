namespace Sharping.Challenges;

public static class DelimiterMatches
{
    public static bool ValidateParenthesis(string value)
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

        return count == 0;
    }

    public static bool CheckMatchingOriginal(string str)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in str)
        {
            if (IsOpening(c))
            {
                stack.Push(c);
                continue;
            }

            if (IsClosing(c))
            {
                if (stack.Count == 0) return false;

                char top = stack.Pop();

                if ((c == ')' && top != '(') || (c == ']' && top != '['))
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }

    public static bool CheckMatching(string str)
    {
        Stack<char> stack = new Stack<char>();

        foreach (var c in str)
        {
            if (IsOpening(c))
            {
                stack.Push(c);
                continue;
            }

            if (stack.Count == 0) return false;

            var top = stack.Pop();

            if (IsInvalidClose(c, top))
            {
                return false;
            }
        }

        return stack.Count == 0;
    }

    public static bool CheckMatching(string str, char[] openingChars, char[] closingChars)
    {
        var stack = new Stack<char>();

        foreach (var c in str)
        {
            if (openingChars.Contains(c))
            {
                stack.Push(c);
                continue;
            }

            if (stack.Count == 0) return false;

            var top = stack.Pop();

            if (!IsValidClose(c, top, openingChars, closingChars))
            {
                return false;
            }
        }

        return stack.Count == 0;
    }

    private static bool IsValidClose(char c, char t, char[] openingChars, char[] closingChars)
    {
        if (!openingChars.Contains(t)) return false;
        if (!closingChars.Contains(c)) return false;

        return Array.IndexOf(openingChars, t) == Array.IndexOf(closingChars, c);
    }

    private static bool IsValidClose(char c, char top)
    {
        switch (c)
        {
            case ')' when top == '(':
            case ']' when top == '[':
                return true;
            default:
                return false;
        }
    }

    private static bool IsInvalidClose(char c, char top) => (c == ')' && top != '(') || (c == ']' && top != '[');

    private static bool IsOpening(char ch) => ch is '(' or '[';

    private static bool IsClosing(char ch) => ch is ')' or ']';
}