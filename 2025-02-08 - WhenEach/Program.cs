using System.Text;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .Enrich.WithThreadId()
    .WriteTo.Console(
        outputTemplate:
        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3} Thread:{ThreadId}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

const string linkText = """
                        https://www.innova.co.ke
                        https://www.facebook.com
                        https://www.google.com
                        https://www.microsoft.com
                        https://www.amazon.com
                        https://www.marvel.com
                        https://www.netflix.com
                        https://www.dc.com
                        https://www.hbo.com
                        https://www.hulu.com
                        https://www.cnn.com
                        https://www.bbc.com
                        https://www.aljazeera.net
                        https://www.kbc.co.ke
                        https://www.standardmedia.co.ke
                        https://www.nation.africa
                        """;

// Split the text into an array if strings
var links = linkText.Split(Environment.NewLine);

// Create a new HttpClient
var client = new HttpClient();
// Set the user agent (some servers reject requests without one!)
client.DefaultRequestHeaders.Add("User-Agent",
    "Mozilla/5.0 (platform; rv:gecko-version) Gecko/gecko-trail Firefox/firefox-version");

// Create a list of tasks
List<Task<(long Bytes, string URL)>> tasks = [];
foreach (var link in links)
    tasks.Add(FetchLink(link));

// Execute the work
await foreach (var task in Task.WhenEach(tasks))
    try
    {
        var result = await task;
        Log.Information("Site {Site} is {Size:#,0} bytes", result.URL, result.Bytes);
    }
    catch (Exception ex)
    {
        Log.Error(ex, "Error occured while fetching site {Site}", task.Result.URL);
    }

return;

// Local function to fetch links
async Task<(long Bytes, string URL)> FetchLink(string link)
{
    // Log request
    Log.Information("Fetching {Link}", link);
    // Send HEAD request to home page
    var result = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, new Uri(link)));
    // Check if the header is present
    if (result.Content.Headers.ContentLength.HasValue)
        return (result.Content.Headers.ContentLength.Value, link);
    // If we are here, fetch the size manually
    var rawResult = await client.GetStringAsync(link);
    // Measure the size 
    return (Encoding.UTF8.GetByteCount(rawResult), link);
}