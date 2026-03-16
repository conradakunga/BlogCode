using System.IO;
using System.IO.Compression;
using System.Reflection;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console().CreateLogger();

// Extract the current folder where the executable is running
var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

// Construct the full path to the zip file
var targetZipFile = Path.Combine(currentFolder, "Books.zip");

// Set the filename
const string fileName = "wealth-of-nations.md";

// Open the zip file on disk for update
await using (var archive = ZipFile.Open(targetZipFile, ZipArchiveMode.Update))
{
    // If the entry exists, delete it 
    var entry = archive.GetEntry(fileName);
    if (entry is not null)
    {
        entry.Delete();
        Log.Information("Deleted {File} from {Target}", fileName, targetZipFile);
    }
    else
    {
        Log.Warning("Could not file {File} in archive", fileName);
    }
}