using System.Diagnostics;
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

Log.Information("Found {TotalLinks} links", links.Length);

// Create a new HttpClient
var client = new HttpClient();
// Set the user agent (some servers reject requests without one!)
client.DefaultRequestHeaders.Add("User-Agent",
    "Mozilla/5.0 (platform; rv:gecko-version) Gecko/gecko-trail Firefox/firefox-version3");

//Start a stopwatch
var sp = Stopwatch.StartNew();
foreach (var link in links)
{
    Log.Information("Requesting {URL}", link);
    try
    {
        // Fetch (but discard) the home page
        _ = await client.GetStringAsync(link);
    }
    catch (Exception ex)
    {
        Log.Error(ex, "Could not fetch {URL}", link);
    }
}

// Stop the stopwatch
sp.Stop();

Log.Information("Elapsed time: {Elapsed}s", sp.Elapsed.TotalSeconds);

var parallelOptions = new ParallelOptions
{
    MaxDegreeOfParallelism = links.Length
};

// Start a stopwatch
sp = Stopwatch.StartNew();
await Parallel.ForEachAsync(links, parallelOptions,
    async (link, cancellationToken) =>
    {
        try
        {
            Log.Information("Fetching {URL}", link);
            await client.GetStringAsync(link, cancellationToken);
            Log.Information("Fetched {URL}", link);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Could not fetch {URL}", link);
        }
    });

// Stop the stopwatch
sp.Stop();

Log.Information("Elapsed time: {Elapsed}s", sp.Elapsed.TotalSeconds);


// Start the stopwatch
sp = Stopwatch.StartNew();

// Create a list of tasks
var tasks = new List<Task>();

// Create task for fetching each link
// and add to the list of tasks
foreach (var link in links)
    tasks.Add(FetchLink(link));

// Wait for completion
await Task.WhenAll(tasks.ToArray());
Log.Information("Elapsed time: {Elapsed}s", sp.Elapsed.TotalSeconds);
return;

// Local function to fetch links
async Task FetchLink(string link)
{
    try
    {
        Log.Information("Fetching {Link}", link);
        await client.GetStringAsync(link);
        Log.Information("Successfully fetched {Link}", link);
    }
    catch (Exception ex)
    {
        Log.Error(ex, "Failed to fetch {Link}", link);
    }
}