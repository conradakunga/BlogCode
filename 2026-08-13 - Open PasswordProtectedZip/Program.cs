using System.IO.Compression;
using System.Reflection;
using Serilog;

// Setup logging
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

// Get the source zip
const string SourceZipFile = "WarAndPeace.zip";

// Set up the location of the target zip file
string targetFile =
    Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "WarAndPeace.txt");

// Set up the zip file password
const string ZipFilePassword = "LeoTolstoy123%#";

// Open the archive
await using (var archive = await ZipFile.OpenReadAsync(SourceZipFile))
{
    // Loop through the entries
    foreach (var entry in archive.Entries)
    {
        Log.Information("Found {Entry}", entry.FullName);

        // Configure extraction options
        var options = new ZipExtractionOptions
        {
            Password = ZipFilePassword.AsMemory(),
        };

        // Extract file
        await entry.ExtractToFileAsync(targetFile, options, CancellationToken.None);

        Log.Information("Successfully extracted {Entry}", entry.FullName);
    }
}