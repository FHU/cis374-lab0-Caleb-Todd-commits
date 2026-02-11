
// [ "ryan", "beau", "caleb", "rye", 
// "beautiful", "cale", "cephas", "rhino", "cervid", "cecily"
// "ethan" , "ethel"]

/// <summary>
/// WordSet implementation using HashSet. 
/// Exact lookups are fast, but ordered/prefix operations scan and sort.
/// </summary>
public sealed class HashWordSet : IWordSet
{
    private HashSet<string> words = new();

    public int Count => words.Count;

    public bool Add(string word)
    {
        return words.Add(word);
    }

    public bool Contains(string word)
    {
        return words.Contains(word);
    }

    public bool Remove(string word)
    {
        return words.Remove(word);
    }

    public string? Prev(string word)
    {
        string? prevword = null;

        foreach(var w in words)
        {
            if(w.CompareTo(word) < 0 && (prevword is null || w.CompareTo(prevword) > 0))
            {
            prevword = w;
            }
        }

        return prevword;
    }

    public string? Next(string word)
    {
        string? nextword = null;

        // look for a better best
        foreach(var w in words)
        {
            // word < w && w < best
            if( word.CompareTo(w) < 0
                && (nextword is null || w.CompareTo(nextword) < 0))
            {
                nextword = w;
            }
        }

        return nextword;
    }

    public IEnumerable<string> Prefix(string prefix, int k)
    {
        var results = new List<string>();

        foreach(var word in words)
        {
            if(word.StartsWith(prefix))
            {
                results.Add(word);
            }
        }

        results.Sort();

        return results.Slice(0, Math.Min(k, results.Count));
    }

    public IEnumerable<string> Range(string low, string high, int k)
    {
        var results = new List<string>();

        foreach(var word in words)
        {
            if(word.CompareTo(low) >= 0 && word.CompareTo(high) <= 0)
            {
                results.Add(word);
            }
        }

        results.Sort();

        return results.Slice(0, Math.Min(k, results.Count));
    }

}
