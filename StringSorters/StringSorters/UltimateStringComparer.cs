using System.Text.RegularExpressions;

namespace StringSorters;

public sealed class UltimateStringComparer : IComparer<string?>
{
    public int Compare(string? left, string? right)
    {
        if (left == right) return 0;
        if (left is null) return -1;
        if (right is null) return 1;

        var reg = new Regex(@"\d+(\.\d+)?");

        // Find the first number in each string
        var leftMatch = reg.Match(left);
        var rightMatch = reg.Match(right);

        if (leftMatch.Success && rightMatch.Success)
        {
            // Numbers were found for both. Compare those
            return decimal.Parse(leftMatch.Captures[0].Value).CompareTo(decimal.Parse(rightMatch.Captures[0].Value));
        }

        // Use the default string comparison
        return string.Compare(left, right, StringComparison.OrdinalIgnoreCase);
    }
}