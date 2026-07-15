using System.Text.RegularExpressions;

var text = "The Quick\r\nBrown Fox\u0085Jumped Over\u2028The Lazy Dog\nBigly";

var oldLines = Regex.Matches(text, @"^.*$", RegexOptions.Multiline).Select(r => r.Value).ToArray();

foreach (var line in oldLines)
{
    Console.WriteLine(line);
}

Console.WriteLine();
Console.WriteLine();

var newLines = Regex.Matches(text, @"^.*$", RegexOptions.Multiline | RegexOptions.AnyNewLine).Select(r => r.Value)
    .ToArray();

foreach (var line in newLines)
{
    Console.WriteLine(line);
}