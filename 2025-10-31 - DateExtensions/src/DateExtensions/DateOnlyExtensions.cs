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

    /// <summary>
    /// Returns the last day of the previous quarter
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateOnly GetEndOfPreviousQuarter(this DateOnly date)
    {
        // Get the start of the current quarter
        var startOfCurrentQuarter = date.GetStartOfQuarter();
        // Subtract one day
        return startOfCurrentQuarter.AddDays(-1);
    }

    /// <summary>
    /// Returns the first day of the previous quarter
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateOnly GetStartOfPreviousQuarter(this DateOnly date)
    {
        // Get the start of the current quarter
        var startOfCurrentQuarter = date.GetStartOfQuarter();
        // Subtract 3 months
        return startOfCurrentQuarter.AddMonths(-3);
    }

    /// <summary>
    /// Returns the first day of the next quarter
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateOnly GetStartOfNextQuarter(this DateOnly date)
    {
        // Get the end of the current quarter
        var endOfCurrentQuarter = date.GetEndOfQuarter();
        // Add a day
        return endOfCurrentQuarter.AddDays(1);
    }

    /// <summary>
    /// Returns the last day of the next quarter
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateOnly GetEndOfNextQuarter(this DateOnly date)
    {
        // Get the start of the next quarter
        var startOfNextQuarter = date.GetStartOfNextQuarter();
        // Get the end of the (now) current quarter
        return startOfNextQuarter.GetEndOfQuarter();
    }
}