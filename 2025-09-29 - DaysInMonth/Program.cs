using System.Globalization;

var dateOnly = new DateOnly(2000, 1, 1);
var gregorian = new GregorianCalendar();
var daysInMonth = gregorian.GetDaysInMonth(dateOnly.Year, dateOnly.Month);
Console.WriteLine($"{dateOnly:MMMM yyyy} has {daysInMonth} days in the Gregorian Calendar");

var hijri = new HijriCalendar();
daysInMonth = hijri.GetDaysInMonth(dateOnly.Year, dateOnly.Month);
Console.WriteLine($"{dateOnly:MMMM yyyy} has {daysInMonth} days in the Hijri Calendar");

var calendar = typeof(Calendar);
// Get the assembly
var calendars = calendar.Assembly
    // Get the types in the assembly
    .GetTypes()
    // Filter out the non-abstract classes, and get those that are assignable
    .Where(t => !t.IsAbstract && calendar.IsAssignableFrom(t))
    // Order by name
    .OrderBy(t => t.Name);

Console.WriteLine("Calendars:");

foreach (var type in calendars!)
{
    Console.WriteLine($"- {type.Name}");
}