// Capture the current time

using Humanizer;

var start = DateTime.Now;
// Wait 65 seconds
await Task.Delay(TimeSpan.FromSeconds(65));
var stop = DateTime.Now;
// Capture the current time
var diff = stop - start;

Console.WriteLine(diff.TotalMinutes);

Console.WriteLine(diff.TotalSeconds);

Console.WriteLine($"{diff.Minutes} minute and {diff.Seconds} seconds");

diff = TimeSpan.FromSeconds(1);

Console.WriteLine($"{diff.Hours} hour, {diff.Minutes} minutes and {diff.Seconds} seconds");

// Sample intervals
diff = TimeSpan.FromHours(180);
Console.WriteLine(diff.Humanize());

diff = TimeSpan.FromHours(168);
Console.WriteLine(diff.Humanize());

diff = TimeSpan.FromHours(60);
Console.WriteLine(diff.Humanize());

diff = TimeSpan.FromHours(50);
Console.WriteLine(diff.Humanize());

diff = TimeSpan.FromMinutes(65);
Console.WriteLine(diff.Humanize());

diff = TimeSpan.FromMinutes(60);
Console.WriteLine(diff.Humanize());

diff = TimeSpan.FromSeconds(65);
Console.WriteLine(diff.Humanize());

diff = TimeSpan.FromSeconds(60);
Console.WriteLine(diff.Humanize());

diff = TimeSpan.FromMilliseconds(1300);
Console.WriteLine(diff.Humanize());

diff = TimeSpan.FromMilliseconds(1000);
Console.WriteLine(diff.Humanize());


// More accurate
diff = TimeSpan.FromHours(180);
Console.WriteLine(diff.Humanize(2));

diff = TimeSpan.FromHours(168);
Console.WriteLine(diff.Humanize(2));

diff = TimeSpan.FromHours(60);
Console.WriteLine(diff.Humanize(2));

diff = TimeSpan.FromHours(50);
Console.WriteLine(diff.Humanize(2));

diff = TimeSpan.FromMinutes(65);
Console.WriteLine(diff.Humanize(2));

diff = TimeSpan.FromMinutes(60);
Console.WriteLine(diff.Humanize(2));

diff = TimeSpan.FromSeconds(65);
Console.WriteLine(diff.Humanize(2));

// Even More accurate
diff = TimeSpan.FromHours(180.5);
Console.WriteLine(diff.Humanize(3));

diff = TimeSpan.FromHours(168.5);
Console.WriteLine(diff.Humanize(3));

diff = TimeSpan.FromHours(60.5);
Console.WriteLine(diff.Humanize(3));

diff = TimeSpan.FromHours(50.5);
Console.WriteLine(diff.Humanize(3));

diff = TimeSpan.FromMinutes(65.5);
Console.WriteLine(diff.Humanize(3));

diff = TimeSpan.FromMinutes(60.5);
Console.WriteLine(diff.Humanize(3));

diff = TimeSpan.FromSeconds(65.5);
Console.WriteLine(diff.Humanize(3));