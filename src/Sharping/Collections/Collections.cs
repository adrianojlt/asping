namespace Sharping.Collections;

public class Collections
{
    public List<string> ToListOrdered(Dictionary<string, Account> accounts)
    {
        var result = accounts
            .OrderByDescending(k => k.Value.Amount)
            .Select(s => $"{s.Value.Id}({s.Value.Amount})");

        return result.ToList();
    }
}