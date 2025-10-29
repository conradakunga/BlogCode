namespace DateExtensions;

public static class DateOnlyExtensions
{
    extension(DateOnly date)
    {
        /// <summary>
        ///  the current quarter of the date
        /// </summary>
        /// <returns></returns>
        public int Quarter =>
            (date.Month - 1) / 3 + 1;

        /// <summary>
        /// Returns the start date of the quarter for the given date.
        /// </summary>
        public DateOnly StartOfQuarter
        {
            get
            {
                int startMonth = (date.Quarter - 1) * 3 + 1;
                return new DateOnly(date.Year, startMonth, 1);
            }
        }

        /// <summary>
        /// Returns the end date of the quarter for the given date.
        /// </summary>
        public DateOnly EndOfQuarter
        {
            get
            {
                int endMonth = date.Quarter * 3;
                int endDay = DateTime.DaysInMonth(date.Year, endMonth);
                return new DateOnly(date.Year, endMonth, endDay);
            }
        }

        /// <summary>
        /// Returns the last day of the previous quarter
        /// </summary>
        /// <returns></returns>
        public DateOnly EndOfPreviousQuarter
        {
            get
            {
                //  the start of the current quarter
                var startOfCurrentQuarter = date.StartOfQuarter;
                // Subtract one day
                return startOfCurrentQuarter.AddDays(-1);
            }
        }

        /// <summary>
        /// Returns the first day of the previous quarter
        /// </summary>
        /// <returns></returns>
        public DateOnly StartOfPreviousQuarter
        {
            get
            {
                //  the start of the current quarter
                var startOfCurrentQuarter = date.StartOfQuarter;
                // Subtract 3 months
                return startOfCurrentQuarter.AddMonths(-3);
            }
        }

        /// <summary>
        /// Returns the first day of the next quarter
        /// </summary>
        /// <returns></returns>
        public DateOnly StartOfNextQuarter
        {
            get
            {
                //  the end of the current quarter
                var endOfCurrentQuarter = date.EndOfQuarter;
                // Add a day
                return endOfCurrentQuarter.AddDays(1);
            }
        }

        /// <summary>
        /// Returns the last day of the next quarter
        /// </summary>
        /// <returns></returns>
        public DateOnly EndOfNextQuarter
        {
            get
            {
                //  the start of the next quarter
                var startOfNextQuarter = date.StartOfNextQuarter;
                //  the end of the (now) current quarter
                return startOfNextQuarter.EndOfQuarter;
            }
        }

        /// <summary>
        /// Returns the start of the current year
        /// </summary>
        /// <returns></returns>
        public DateOnly StartOfCurrentYear =>
            // Create a new dateonly using the current year, first day, and first month (Jan)
            new(date.Year, 1, 1);

        /// <summary>
        /// Returns the end of the current year
        /// </summary>
        /// <returns></returns>
        public DateOnly EndOfCurrentYear
        {
            get
            {
                //  the start of the current year
                var startOfCurrentYear = date.StartOfCurrentYear;
                // Push to the next year
                var startOfNextYear = new DateOnly(startOfCurrentYear.Year + 1, 1, 1);
                // Advance to end of current year
                return startOfNextYear.AddDays(-1);
            }
        }

        /// <summary>
        /// Returns the start of the previous year
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateOnly StartOfPreviousYear =>
            // Create a new dateonly using the current year minus one, first day, and first month (Jan)
            new DateOnly(date.Year - 1, 1, 1);

        /// <summary>
        /// Returns the end of the previous year
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateOnly EndOfPreviousYear
        {
            get
            {
                //  the start of the previous year
                var startOfPreviousYear = date.StartOfPreviousYear;
                // Return the end of that year
                return startOfPreviousYear.EndOfCurrentYear;
            }
        }

        /// <summary>
        /// Returns the start of the next year
        /// </summary>
        /// <returns></returns>
        public DateOnly StartOfNextYear =>
            // Create a new dateonly using the current year plus one, first day, and first month (Jan)
            new DateOnly(date.Year + 1, 1, 1);

        /// <summary>
        /// Return the end of the next year
        /// </summary>
        /// <returns></returns>
        public DateOnly EndOfNextYear
        {
            get
            {
                //  the start of the next year
                var startOfNextYear = date.StartOfNextYear;
                // Return the end of that year
                return startOfNextYear.EndOfCurrentYear;
            }
        }
    }
}