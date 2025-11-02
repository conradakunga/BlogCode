namespace DateExtensions;

public static class DateOnlyExtensions
{
    extension(DateOnly)
    {
        /// <summary>
        /// Create a new DateOnly offset by selected number of years
        /// </summary>
        /// <returns></returns>
        public static DateOnly CreateCurrentWithOffsetYear(int years)
        {
            var now = DateOnly.FromDateTime(DateTime.Now);
            return new DateOnly(now.Year + years, now.Month, now.Day);
        }
    }
}
