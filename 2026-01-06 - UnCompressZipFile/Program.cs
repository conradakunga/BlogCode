using System.IO.Compression;
using System.Reflection;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console().CreateLogger();

const string sourceZipFile = "war-and-peace.zip";
const string textFileName = "war-and-peace.txt";

// Extract the current folder where the executable is running
var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
// Construct the full path to the extracted text file
var targetTextFile = Path.Combine(currentFolder!, textFileName);


// Open the zip file and extract file 
await using (var archive = await ZipFile.OpenReadAsync(sourceZipFile))
{
    // Find our entry
    var entry = archive.GetEntry(textFileName);
    // If not null, extract. Overwrite if it exists
    entry?.ExtractToFile(targetTextFile, overwrite: true);
}

Log.Information("Written {SourceZipFile} to {TargetTextFile}", sourceZipFile, targetTextFile);