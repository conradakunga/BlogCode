using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using Serilog;
using ValidateLinks.Core;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var urlRegex = UrlRegex();
var urls = new ConcurrentBag<string>();

const string root = "/Users/rad/Projects/blog/Blog/_posts";
var files = Directory.GetFiles(root);
// Configure parallel options
var options = new ParallelOptions { MaxDegreeOfParallelism = 45 };

// Validate links in a loop
await Parallel.ForEachAsync(files, options,
    async (file, cancel) =>
    {
        var text = await File.ReadAllTextAsync(file, cancel);
        var matches = urlRegex.Matches(text);
        foreach (Match match in matches)
        {
            var url = match.Groups["url"].Value;
            // Ignore relative links & jekyll links
            if (!(url.StartsWith("..") || url.StartsWith("{")) && !string.IsNullOrWhiteSpace(url))
                urls.Add(url);
        }
    });

var validator = new LinkValidator();
var result = await validator.ValidateAsync(urls);
var invalid = result.Where(x => !x.Success).ToList();
invalid.ForEach(Console.WriteLine);

partial class Program
{
    [GeneratedRegex(@"\[(?<name>.*?)\]\((?<url>.*?)\)")]
    private static partial Regex UrlRegex();
}