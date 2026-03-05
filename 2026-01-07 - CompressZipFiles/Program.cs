using System.IO.Compression;
using System.Reflection;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console().CreateLogger();

// Extract the current folder where the executable is running
var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

// Construct the full path to the source files
var folderWithBooks = Path.Combine(currentFolder!, "Books");

// Construct the full path to the zip file
var targetZipFile = Path.Combine(folderWithBooks, "Books.zip");

// Delete the zip file if it exists
if (File.Exists(targetZipFile))
    File.Delete(targetZipFile);

// Retrieve the files
var filesToZip = Directory.GetFiles(folderWithBooks);

// Create the zip file on disk
await using (var archive = ZipFile.Open(targetZipFile, ZipArchiveMode.Create))
{
    foreach (var file in filesToZip)
    {
        // Add each file to the zip file as an entry
        await archive.CreateEntryFromFileAsync(file, Path.GetFileName(file), CompressionLevel.Optimal);
    }
}

Log.Information("Written files in {SourceFiles} to {TargetZipFile}", folderWithBooks, targetZipFile);