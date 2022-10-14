// Print the various values of ticks
Console.WriteLine($"TimeSpan.TicksPerMicrosecond - {TimeSpan.TicksPerMicrosecond:#,0}");
Console.WriteLine($"TimeSpan.TicksPerMillisecond - {TimeSpan.TicksPerMillisecond:#,0}");
Console.WriteLine($"TimeSpan.TicksPerSecond - {TimeSpan.TicksPerSecond:#,0}");
Console.WriteLine($"TimeSpan.TicksPerMinute - {TimeSpan.TicksPerMinute:#,0}");
Console.WriteLine($"TimeSpan.TicksPerHour - {TimeSpan.TicksPerHour:#,0}");
Console.WriteLine($"TimeSpan.TicksPerDay - {TimeSpan.TicksPerDay:#,0}");

// Create the most accurate date
var now = new DateTime(2022, 10, 14, 14, 58, 10, 10);

// Add on the ticks
var preciselyNow = new DateTime(now.Ticks + 999 * TimeSpan.TicksPerMicrosecond);

// Write the date
Console.WriteLine(preciselyNow);

// Check the ticks
Console.WriteLine(preciselyNow.Ticks);

// Create using new .NET 7 constructor

var nowAgain = new DateTime(2022, 10, 14, 14, 58, 10, 10, 999);

// Write the date
Console.WriteLine(nowAgain);

// Check the ticks
Console.WriteLine(nowAgain.Ticks);
