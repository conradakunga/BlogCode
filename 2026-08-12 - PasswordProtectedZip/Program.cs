using System.IO.Compression;
using System.Reflection;
using Serilog;

// Setup logging
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

// Set up the location of the target zip file
string targetZipFile =
    Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "WarAndPeace.zip");
// Set up the zip file password
const string ZipFilePassword = "LeoTolstoy123%#";

// Create the archive
await using (var archive = ZipFile.Open(targetZipFile, ZipArchiveMode.Create))
{
    // Add the file to the zip archive
    await archive.CreateEntryFromFileAsync("war-and-peace.txt", "War And Peace",
        CompressionLevel.SmallestSize,
        ZipFilePassword.AsMemory(), ZipEncryptionMethod.Aes256, CancellationToken.None);

    Log.Information("Compressed file to {ZipFile}", new FileInfo(targetZipFile).Name);
}