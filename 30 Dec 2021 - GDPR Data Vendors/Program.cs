using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Serilog;
using System.Linq;
using System.Text;

namespace GDPR
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            // Define the regex to extact vendor and url
            var reg = new Regex("\"vendor-title\">(?<company>.*?)<.*?vendor-privacy-notice\".*?href=\"(?<url>.*?)\"",
                RegexOptions.Compiled);

            // Load the vendors into a string, and replace all newlines with spaces to mitigate
            // formatting issues from irregular use of the newline
            var vendors = File.ReadAllText("vendors.html").Replace(Environment.NewLine, " ");

            // Match against the vendors html file
            var matches = reg.Matches(vendors);

            Log.Information("There were {num} matches", matches.Count);

            // extract the vendor number, name and their url, ordering by the name first.
            var vendorInfo = matches.OrderBy(match => match.Groups["company"].Value)
                .Select((match, index) =>
                  new
                  {
                      Index = index + 1,
                      Name = match.Groups["company"].Value,
                      URL = match.Groups["url"].Value
                  });

            // Create a string builder to progressively build the markdown
            var sb = new StringBuilder();

            // Append headers
            sb.AppendLine($"Listing As At 30 December 2020 08:10 GMT");
            sb.AppendLine();
            sb.AppendLine("|-|Vendor| URL |");
            sb.AppendLine("|---|---|---|");

            // Append the vendor details
            foreach (var vendor in vendorInfo)
                sb.AppendLine($"|{vendor.Index}|{vendor.Name}|[{vendor.URL}]({vendor.URL})|");

            // Delete existing markdown file, if present
            if (File.Exists("vendors.md"))
                File.Delete("vendors.md");

            //Write markdown to file
            File.WriteAllText("vendors.md", sb.ToString());
        }
    }
}
