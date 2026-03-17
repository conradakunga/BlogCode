using System.IO;
using System.IO.Compression;
using System.Reflection;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console().CreateLogger();

// Extract the current folder where the executable is running
var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

// Construct the full path to the zip file
var zipFile = Path.Combine(currentFolder, "Books.zip");

// Open the zip file on disk for update
await using (var archive = await ZipFile.OpenAsync(zipFile, ZipArchiveMode.Read))
{
    // Loop through all the entries
    for (var i = 0; i < archive.Entries.Count; i++)
    {
        // Get the file name
        var file = archive.Entries[i];
        // Print the count and name
        Log.Information("File {Count} - {FileMame}", i + 1, file.FullName);
    }
}