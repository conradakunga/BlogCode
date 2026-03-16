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

// Construct the full path to the file to add
var fileToAdd = Path.Combine(currentFolder, fileName);

// Open the zip file on disk for update
await using (var archive = ZipFile.Open(targetZipFile, ZipArchiveMode.Update))
{
    // Ensure the file does not already exist. Return if it does
    if (archive.GetEntry(fileName) != null)
    {
        Log.Warning("The file {File} already exists in the zip file", fileToAdd);
        return;
    }

    // Add the file to the archive
    archive.CreateEntryFromFile(fileToAdd, fileName, CompressionLevel.Optimal);
}


Log.Information("Updated {TargetZipFile}", targetZipFile);