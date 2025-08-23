using System.Text.RegularExpressions;

namespace StringSorters;

public sealed partial class MagnificentStringComparer : IComparer<string?>
{
    private static readonly Regex DecimalRegex = MatchDecimalRegex();
    private static readonly Regex LeadingStringRegex = MatchLeadingStringRegex();

    public int Compare(string? left, string? right)
    {
        if (left == right) return 0;
        if (left is null) return -1;
        if (right is null) return 1;

        // First, try grab both leading strings
        var leftStringMatch = LeadingStringRegex.Match(left);
        var rightStringMatch = LeadingStringRegex.Match(right);

        // if both matches didn't succeed, use the normal string comparison
        if (!leftStringMatch.Success && !rightStringMatch.Success)
            return string.Compare(left, right, StringComparison.OrdinalIgnoreCase);

        // if only one match succeeded, use normal string comparison
        if (leftStringMatch.Success != rightStringMatch.Success)
            return string.Compare(left, right, StringComparison.OrdinalIgnoreCase);

        // Here, both matches succeeded. Compare the captured leading strings
        var comparison = string.Compare(leftStringMatch.Groups[1].Value, rightStringMatch.Groups[1].Value,
            StringComparison.OrdinalIgnoreCase);

        // If the leading strings are different, don't bother going any further
        if (comparison != 0) return comparison;

        // If both leading strings are the same, now compare the numbers

        // Find the first number in each string
        var leftDecimalMatch = DecimalRegex.Match(left);
        var rightDecimalMatch = DecimalRegex.Match(right);

        if (leftDecimalMatch.Success && rightDecimalMatch.Success)
        {
            // Numbers were found for both. Compare those
            return decimal.Parse(leftDecimalMatch.Value).CompareTo(decimal.Parse(rightDecimalMatch.Value));
        }

        // Use the default string comparison
        return string.Compare(left, right, StringComparison.OrdinalIgnoreCase);
    }

    [GeneratedRegex(@"\d+(\.\d+)?", RegexOptions.Compiled)]
    private static partial Regex MatchDecimalRegex();


    [GeneratedRegex(@"^(\w+)\s*\d", RegexOptions.Compiled)]
    private static partial Regex MatchLeadingStringRegex();
}