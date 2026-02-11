public sealed class SortedWordSet : IWordSet
{
    private SortedSet<string> words = new();

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
        if (words.TryGetValue(word, out _))
        {
            // Word exists, find the previous word
            foreach (var w in words.Reverse())
            {
                if (w.CompareTo(word) < 0)
                    return w;
            }
        }
        else
        {
            // Word doesn't exist, find the largest word less than it
            foreach (var w in words.Reverse())
            {
                if (w.CompareTo(word) < 0)
                    return w;
            }
        }
        return null;
    }

    public string? Next(string word)
    {
        if (words.TryGetValue(word, out _))
        {
            // Word exists, find the next word
            foreach (var w in words)
            {
                if (w.CompareTo(word) > 0)
                    return w;
            }
        }
        else
        {
            // Word doesn't exist, find the next smallest word
            foreach (var w in words)
            {
                if (w.CompareTo(word) > 0)
                    return w;
            }
        }
        return null;
    }

    public IEnumerable<string> Prefix(string prefix, int k)
    {
        var results = new List<string>();

        foreach (var word in words)
        {
            if (word.StartsWith(prefix))
            {
                results.Add(word);
            }
        }

        return results.Take(k);
    }

    public IEnumerable<string> Range(string low, string high, int k)
    {
        var results = new List<string>();

        foreach (var word in words)
        {
            if (word.CompareTo(low) >= 0 && word.CompareTo(high) <= 0)
            {
                results.Add(word);
            }
        }

        return results.Take(k);
    }
}
