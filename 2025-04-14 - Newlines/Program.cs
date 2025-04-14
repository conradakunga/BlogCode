const string windows = "/Users/rad/WindowsShare/Windows.txt";
const string osx = "/Users/rad/WindowsShare/OSX.txt";

var windowsText = File.ReadAllText(windows);
var osxText = File.ReadAllText(osx);

// // Print all the lines from Windows
// Console.WriteLine("WINDOWS");
// foreach (var entry in windowsText.Split(Environment.NewLine))
// {
//     Console.WriteLine(entry);
// }
//
// // Print all the lines from Windows
// Console.WriteLine("OSX");
// foreach (var entry in osxText.Split(Environment.NewLine))
// {
//     Console.WriteLine(entry);
// }

// Print all the lines from Windows
Console.WriteLine("WINDOWS");
foreach (var entry in windowsText.Split(Environment.NewLine).Select(x => new { Text = x, Length = x.Length }))
{
    Console.WriteLine($"Text:{entry.Text}, Length:{entry.Length}");
}

// Print all the lines from Windows
Console.WriteLine("OSX");
foreach (var entry in osxText.Split(Environment.NewLine).Select(x => new { Text = x.Trim(), Length = x.Length }))
{
    Console.WriteLine($"Text:{entry.Text}, Length:{entry.Length}");
}