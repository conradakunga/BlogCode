using System.IO;
using System.IO.Compression;
using System.Reflection;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console().CreateLogger();

// Extract the current folder where the executable is running
var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

// Construct the full path to the zip file
var zipFile = Path.Combine(currentFolder, "Updated.zip");

// Open the zip file on disk for update
await using (var archive = await ZipFile.OpenAsync(zipFile, ZipArchiveMode.Read))
{
    var counter = 1;
    // Loop through all the entries
    foreach (var file in archive.Entries)
    {
        // Get the file name, and skip if it is a directory
        if (file.Name == string.Empty) continue;
        Log.Information("==========================");
        Log.Information("File # {Index}", counter++);
        Log.Information("Name {FileName}", file.Name);
        Log.Information("Path {FullName}", file.FullName);
        Log.Information("Size {OriginalSize:#,0} bytes", file.Length);
        Log.Information("Compressed Size {CompressedSize:#,0} bytes", file.CompressedLength);
        Log.Information("CRC {CRC}", file.Crc32);
        Log.Information("Encrypted? {Encrypted}", file.IsEncrypted);
        Log.Information("Last Write Time {LastWriteTime:d MMM yyyy HH:mm}", file.LastWriteTime);
    }
}