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
        // Check if the file is compressed
        switch (file.CompressionMethod)
        {
            case ZipCompressionMethod.Stored:
                Log.Information("File {FileName} is not compressed", file.Name);
                break;
            case ZipCompressionMethod.Deflate:
                Log.Information("File {FileName} is compressed using Deflate", file.Name);
                break;
            case ZipCompressionMethod.Deflate64:
                Log.Information("File {FileName} is compressed using Deflate64", file.Name);
                break;
            default:
                Log.Warning("Unknown compression");
                break;
        }

        if (file.CompressedLength != file.Length)
            // Print the count and name
            Log.Information("File {Count} - {FileName}", i + 1, file.FullName);
    }
}