namespace Sharping.Delegates;

public class Delegates
{
    public delegate string StringDelegate(string text);

    public delegate string DoStuff(string name, int age);
    public delegate string DoMoreStuff(string name, int age);

    public static List<Student> students = new()
    {
        new Student(55, "Paul"),
        new Student(66, "John")
    };

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

    public static string PrintStuff(string name, int age)
    {
        DoStuff doStuff = new DoStuff(Concatenate);
        return doStuff(name, age);
    }

    public static string PrintMoreStuff(string name, int age)
    {
        Func<string, int, string> doMoreStuff = Concatenate;
        return doMoreStuff(name, age);
    }

    private static string Concatenate(string name, int age)
    {
        return $"{name}@{age}";
    }
    
    public static string RemoveAtSign(string address) => address.Replace("@", string.Empty);

    public static string RemoveDots(string address) => address.Replace(".", string.Empty);
  
}
