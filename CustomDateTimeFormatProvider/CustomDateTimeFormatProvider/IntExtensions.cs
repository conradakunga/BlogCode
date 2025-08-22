namespace CustomDateTimeFormatProvider;

public static class IntExtensions
{
    public static string GetDaySuffix(this int day)
    {
        // Edge case for 11, 12 and 13
        if (day is >= 11 and <= 13) return "th";

        // All othera
        return (day % 10) switch
        {
            1 => "st",
            2 => "nd",
            3 => "rd",
            _ => "th"
        };
    }
}