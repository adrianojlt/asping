namespace Sharping.Delegates;

public class Delegates
{
    public delegate string StringDelegate(string text);

    public static string DelegateToUpper(string text) 
    {
        StringDelegate sd = ToUpperCase;
        return sd(text);
    }

    public static string DelegateToLower(string text)
    {
        StringDelegate sd = ToLowerCase;
        return sd.Invoke(text);
    }

    public static string ToUpperCase(string text) => text.ToUpper();

    public static string ToLowerCase(string text) => text.ToLower();

}
