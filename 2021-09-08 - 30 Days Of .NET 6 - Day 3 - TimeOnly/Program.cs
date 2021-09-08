// Three different constructors
var time = new TimeOnly(9, 30);
var timeWithSeconds = new TimeOnly(9, 30, 30);
var timeWithMilliSeconds = new TimeOnly(9, 30, 30, 99);

// Obtain from a Timespan
var span = TimeSpan.FromMinutes(10);
var timeFromSpan = TimeOnly.FromTimeSpan(span);

// Obtain from datetime
var now = TimeOnly.FromDateTime(DateTime.Now);

// Adding periods
var future = TimeOnly.FromDateTime(DateTime.Now)
    .AddHours(1)
    .AddMinutes(30)
    .Add(TimeSpan.FromMilliseconds(5));

// Wrapping

// Passing no arguments assume you want to start at 0:00.00.000000
var newYearEve = new TimeOnly().AddMinutes(-4);

var newYearEveWrapped = new TimeOnly().AddMinutes(-4, out var daysWrapped);

var midnight = new TimeOnly(0, 0);
var noon = new TimeOnly(12, 0);

if (now.IsBetween(midnight, noon))
    Console.WriteLine("Good morning");
else
    Console.WriteLine("Good afternoon/evening");

// Subtract the two timespans
var difference = midnight - noon;