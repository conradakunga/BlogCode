namespace DateExtensions;

public static class DateTimeExtensions
{
    private static readonly TimeSpan LargestTime = TimeSpan.FromDays(1).Add(TimeSpan.FromTicks(-10));

    /// <summary>
    /// Get the current quarter of the date
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static int Quarter(this DateTime date)
    {
        return DateOnly.FromDateTime(date).Quarter();
    }

    /// <summary>
    /// Returns the start date of the quarter for the given date.
    /// </summary>
    public static DateTime GetStartOfQuarter(this DateTime date)
    {
        return DateOnly.FromDateTime(date).GetStartOfQuarter().ToDateTime(TimeOnly.MinValue);
    }

    /// <summary>
    /// Returns the end date of the quarter for the given date.
    /// </summary>
    public static DateTime GetEndOfQuarter(this DateTime date)
    {
        return DateOnly.FromDateTime(date).GetEndOfQuarter().ToDateTime(TimeOnly.MinValue).Add(LargestTime);
    }

    /// <summary>
    /// Returns the last day of the previous quarter
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime GetEndOfPreviousQuarter(this DateTime date)
    {
        return DateOnly.FromDateTime(date).GetEndOfPreviousQuarter().ToDateTime(TimeOnly.MinValue).Add(LargestTime);
    }

    /// <summary>
    /// Returns the first day of the previous quarter
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime GetStartOfPreviousQuarter(this DateTime date)
    {
        return DateOnly.FromDateTime(date).GetStartOfPreviousQuarter().ToDateTime(TimeOnly.MinValue);
    }

    /// <summary>
    /// Returns the first day of the next quarter
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime GetStartOfNextQuarter(this DateTime date)
    {
        return DateOnly.FromDateTime(date).GetStartOfNextQuarter().ToDateTime(TimeOnly.MinValue);
    }

    /// <summary>
    /// Returns the last day of the next quarter
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime GetEndOfNextQuarter(this DateTime date)
    {
        return DateOnly.FromDateTime(date).GetEndOfNextQuarter().ToDateTime(TimeOnly.MinValue).Add(LargestTime);
    }

    /// <summary>
    /// Returns the start of the current year
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime GetStartOfCurrentYear(this DateTime date)
    {
        return DateOnly.FromDateTime(date).GetStartOfCurrentYear().ToDateTime(TimeOnly.MinValue);
    }

    /// <summary>
    /// Returns the end of the current year
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime GetEndOfCurrentYear(this DateTime date)
    {
        return DateOnly.FromDateTime(date).GetEndOfCurrentYear().ToDateTime(TimeOnly.MinValue).Add(LargestTime);
    }

    /// <summary>
    /// Returns the start of the previous year
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime GetStartOfPreviousYear(this DateTime date)
    {
        return DateOnly.FromDateTime(date).GetStartOfPreviousYear().ToDateTime(TimeOnly.MinValue);
    }

    /// <summary>
    /// Returns the end of the previous year
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime GetEndOfPreviousYear(this DateTime date)
    {
        return DateOnly.FromDateTime(date).GetEndOfPreviousYear().ToDateTime(TimeOnly.MinValue).Add(LargestTime);
    }

    /// <summary>
    /// Returns the start of the next year
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime GetStartOfNextYear(this DateTime date)
    {
        return DateOnly.FromDateTime(date).GetStartOfNextYear().ToDateTime(TimeOnly.MinValue);
    }

    /// <summary>
    /// Return the end of the next year
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime GetEndOfNextYear(this DateTime date)
    {
        return DateOnly.FromDateTime(date).GetEndOfNextYear().ToDateTime(TimeOnly.MinValue).Add(LargestTime);
    }
}