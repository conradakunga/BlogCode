namespace DateExtensions;

public static class DateOnlyExtensions
{
    /// <summary>
    /// Get the current quarter of the date
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static int Quarter(this DateOnly date)
    {
        return (date.Month - 1) / 3 + 1;
    }

    /// <summary>
    /// Returns the start date of the quarter for the given date.
    /// </summary>
    public static DateOnly GetStartOfQuarter(this DateOnly date)
    {
        int startMonth = (date.Quarter() - 1) * 3 + 1;
        return new DateOnly(date.Year, startMonth, 1);
    }

    /// <summary>
    /// Returns the end date of the quarter for the given date.
    /// </summary>
    public static DateOnly GetEndOfQuarter(this DateOnly date)
    {
        int endMonth = date.Quarter() * 3;
        int endDay = DateTime.DaysInMonth(date.Year, endMonth);
        return new DateOnly(date.Year, endMonth, endDay);
    }
}