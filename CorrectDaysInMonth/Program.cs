using System.Globalization;

var dateOnly = new DateOnly(2000, 1, 1);
var gregorian = new GregorianCalendar();
var daysInMonth = gregorian.GetDaysInMonth(dateOnly.Year, dateOnly.Month);
Console.WriteLine($"{dateOnly:MMMM yyyy} has {daysInMonth} days in the Gregorian Calendar");

var hijri = new HijriCalendar();
daysInMonth = hijri.GetDaysInMonth(dateOnly.Year, dateOnly.Month);
Console.WriteLine($"{dateOnly:MMMM yyyy} has {daysInMonth} days in the Hijri Calendar");