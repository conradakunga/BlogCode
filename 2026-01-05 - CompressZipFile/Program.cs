using System.IO.Compression;
using System.Reflection;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console().CreateLogger();

const string sourceFile = "war-and-peace.txt";

// Extract the current folder where the executable is running
var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
// Construct the full path to the zip file
var targetZipFile = Path.Combine(currentFolder!, "war-and-peace.zip");

// Check if zip file exists. If so, delete it
if (File.Exists(targetZipFile))
    File.Delete(targetZipFile);

// Create a zip file with the maximum compression
await using (var archive = await ZipFile.OpenAsync(targetZipFile, ZipArchiveMode.Create))
{
    await archive.CreateEntryFromFileAsync(sourceFile, Path.GetFileName(sourceFile), CompressionLevel.SmallestSize);
}

Log.Information("Written {SourceFile} to {TargetZipFile}", sourceFile, targetZipFile, targetZipFile);