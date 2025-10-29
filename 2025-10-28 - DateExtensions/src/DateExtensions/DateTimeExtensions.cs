namespace DateExtensions;

public static class DateTimeExtensions
{
    private static readonly TimeSpan LargestTime = TimeSpan.FromDays(1).Add(TimeSpan.FromTicks(-10));

    extension(DateTime date)
    {
        /// <summary>
        /// Get the current quarter of the date
        /// </summary>
        /// <returns></returns>
        public int Quarter => DateOnly.FromDateTime(date).Quarter;

        /// <summary>
        /// Returns the start date of the quarter for the given date.
        /// </summary>
        public DateTime StartOfQuarter => DateOnly.FromDateTime(date).StartOfQuarter.ToDateTime(TimeOnly.MinValue);

        /// <summary>
        /// Returns the end date of the quarter for the given date.
        /// </summary>
        public DateTime EndOfQuarter =>
            DateOnly.FromDateTime(date).EndOfQuarter.ToDateTime(TimeOnly.MinValue).Add(LargestTime);

        /// <summary>
        /// Returns the last day of the previous quarter
        /// </summary>
        /// <returns></returns>
        public DateTime EndOfPreviousQuarter =>
            DateOnly.FromDateTime(date).EndOfPreviousQuarter.ToDateTime(TimeOnly.MinValue).Add(LargestTime);

        /// <summary>
        /// Returns the first day of the previous quarter
        /// </summary>
        /// <returns></returns>
        public DateTime StartOfPreviousQuarter =>
            DateOnly.FromDateTime(date).StartOfPreviousQuarter.ToDateTime(TimeOnly.MinValue);

        /// <summary>
        /// Returns the first day of the next quarter
        /// </summary>
        /// <returns></returns>
        public DateTime StartOfNextQuarter =>
            DateOnly.FromDateTime(date).StartOfNextQuarter.ToDateTime(TimeOnly.MinValue);

        /// <summary>
        /// Returns the last day of the next quarter
        /// </summary>
        /// <returns></returns>
        public DateTime EndOfNextQuarter =>
            DateOnly.FromDateTime(date).EndOfNextQuarter.ToDateTime(TimeOnly.MinValue).Add(LargestTime);

        /// <summary>
        /// Returns the start of the current year
        /// </summary>
        /// <returns></returns>
        public DateTime StartOfCurrentYear =>
            DateOnly.FromDateTime(date).StartOfCurrentYear.ToDateTime(TimeOnly.MinValue);

        /// <summary>
        /// Returns the end of the current year
        /// </summary>
        /// <returns></returns>
        public DateTime EndOfCurrentYear =>
            DateOnly.FromDateTime(date).EndOfCurrentYear.ToDateTime(TimeOnly.MinValue).Add(LargestTime);

        /// <summary>
        /// Returns the start of the previous year
        /// </summary>
        /// <returns></returns>
        public DateTime StartOfPreviousYear =>
            DateOnly.FromDateTime(date).StartOfPreviousYear.ToDateTime(TimeOnly.MinValue);

        /// <summary>
        /// Returns the end of the previous year
        /// </summary>
        /// <returns></returns>
        public DateTime EndOfPreviousYear =>
            DateOnly.FromDateTime(date).EndOfPreviousYear.ToDateTime(TimeOnly.MinValue).Add(LargestTime);

        /// <summary>
        /// Returns the start of the next year
        /// </summary>
        /// <returns></returns>
        public DateTime StartOfNextYear =>
            DateOnly.FromDateTime(date).StartOfNextYear.ToDateTime(TimeOnly.MinValue);

        /// <summary>
        /// Return the end of the next year
        /// </summary>
        /// <returns></returns>
        public DateTime EndOfNextYear =>
            DateOnly.FromDateTime(date).EndOfNextYear.ToDateTime(TimeOnly.MinValue).Add(LargestTime);
    }
}