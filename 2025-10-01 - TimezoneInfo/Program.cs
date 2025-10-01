using NodaTime;
using NodaTime.Text;

// Get the current time
var now = SystemClock.Instance.GetCurrentInstant();

Console.WriteLine($"It is {now:ddd, d MMM yyyy h:mm tt} in Nairobi");
Console.WriteLine();

// Build an array of zone info types
ZoneInfo[] zones =
[
    new("Algiers", "Africa/Algiers"),
    new("Wollongong", "Australia/Sydney"),
    new("London", "Europe/London"),
    new("Dublin", "Europe/Dublin"),
    new("Cape Town", "Africa/Johannesburg"),
    new("San Francisco", "America/Los_Angeles")
];

// Build the display pattern for the date and time
var pattern = ZonedDateTimePattern.CreateWithInvariantCulture("ddd d MMM yyyy, h:mm tt", DateTimeZoneProviders.Tzdb);

foreach (var zone in zones)
{
    // Get the current zone date time
    var zonedDateTime = now.InZone(DateTimeZoneProviders.Tzdb[zone.TimeZone]);
    // Output
    Console.WriteLine($"{zone.City} - {pattern.Format(zonedDateTime)}");
}

internal record ZoneInfo(string City, string TimeZone);