namespace StringSorters;

public sealed class NumericStringComparer : IComparer<string?>
{
    public int Compare(string? left, string? right)
    {
        if (left == right) return 0;
        if (left is null) return -1;
        if (right is null) return 1;

        // Try parse both as integers
        if (int.TryParse(left, out int x) && int.TryParse(right, out int y))
        {
            // Compare the numbers using the integer comparer
            return x.CompareTo(y);
        }

        // Use the default string comparison
        return string.Compare(left, right, StringComparison.OrdinalIgnoreCase);
    }
}