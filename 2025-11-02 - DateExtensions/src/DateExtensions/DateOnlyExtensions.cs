using System.Globalization;
using Humanizer;

namespace DateExtensions;

public static class DateOnlyExtensions
{
    extension(DateOnly)
    {
        /// <summary>
        /// Return the calendar name for the current culture
        /// </summary>
        /// <returns></returns>
        public static string CalendarName
        {
            get
            {
                var calendar = CultureInfo.CurrentCulture.Calendar;
                return calendar.GetType().Name.Humanize();
            }
        }
    }
}