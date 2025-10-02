using NodaTime;
using NodaTime.Text;

// Print current system date
Console.WriteLine($"It is {DateTime.Now:ddd, d MMM yyyy h:mm tt} in Nairobi");
Console.WriteLine();

// Get the current time as an Instant
var now = SystemClock.Instance.GetCurrentInstant();

// Build an array of zone info types
ZoneInfo[] zones =
[
    new("Algiers", "Africa/Algiers"),
    new("Atlanta", "America/Los_Angeles"),
    new("Wollongong", "Australia/Sydney"),
    new("London", "Europe/London"),
    new("Dublin", "Europe/Dublin"),
    new("Cape Town", "Africa/Johannesburg"),
    new("San Francisco", "America/Los_Angeles"),
    new("San José", "America/Los_Angeles")
];

// Build the display pattern for the date and time
var pattern = ZonedDateTimePattern.CreateWithInvariantCulture("ddd d MMM yyyy, h:mm tt", DateTimeZoneProviders.Tzdb);

foreach (var zone in zones.OrderBy(x => x.City))
{
    // Get the current zone date time
    var zonedDateTime = now.InZone(DateTimeZoneProviders.Tzdb[zone.TimeZone]);
    // Output
    Console.WriteLine($"{zone.City} - {pattern.Format(zonedDateTime)}");
}

internal record ZoneInfo(string City, string TimeZone);