using System.Formats.Tar;
using System.IO.Compression;
using System.Reflection;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

const string sourceFilesDirectoryName = "Books";

// Extract the current folder where the executable is running
var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

// Build the intermediate paths
var sourceFilesDirectory = Path.Combine(currentFolder, sourceFilesDirectoryName);
var targetTarFile = Path.Combine(currentFolder, $"{sourceFilesDirectoryName}.tar");
var targetGzipFile = Path.Combine(currentFolder, $"{sourceFilesDirectoryName}.tar.gz");

// Cleanup if necessary
if (File.Exists(targetTarFile))
    File.Delete(targetTarFile);

if (File.Exists(targetGzipFile))
    File.Delete(targetGzipFile);

var filesToCompress = Directory.GetFiles(sourceFilesDirectory);

// {
//     //
//     // This version uses a stream
//     //
//
//     // Create a stream, and use a TarWriter to write files to this stream
//     await using (var stream = File.Create(targetTarFile))
//     {
//         await using (var writer = new TarWriter(stream))
//         {
//             foreach (var file in filesToCompress)
//             {
//                 await writer.WriteEntryAsync(file, Path.GetFileName(file));
//             }
//         }
//     }
//
//     // Create a gzip stream for the target
//     await using (var gzip = new GZipStream(File.Create(targetGzipFile), CompressionLevel.Optimal))
//     {
//         // Read the source file and copy into the gzip stream
//         await using (var input = File.OpenRead(targetTarFile))
//         {
//             await input.CopyToAsync(gzip);
//         }
//     }
// }
//
// {
//     //
//     // This version uses the static helper method
//     //
//
//     // Create the target tar file, with the folder as the root
//     await TarFile.CreateFromDirectoryAsync(sourceFilesDirectory, targetGzipFile, true);
//
//     // Create a gzip stream for the target
//     await using (var gzip = new GZipStream(File.Create(targetGzipFile), CompressionLevel.Optimal))
//     {
//         // Read the source file and copy into the gzip stream
//         await using (var input = File.OpenRead(targetTarFile))
//         {
//             await input.CopyToAsync(gzip);
//         }
//     }
// }
{
    //
    // This version uses streams directly
    //

    // Create a stream for the target gzip file
    await using (var fileStream = File.Create(targetGzipFile))
    {
        // Create a GzipStream from the previous steam
        await using (var gzip = new GZipStream(fileStream, CompressionLevel.Optimal))
        {
            // Create a TarWriter with the GzipStrea,
            await using (var writer = new TarWriter(gzip))
            {
                // Write the files to the stream
                foreach (var file in filesToCompress)
                {
                    await writer.WriteEntryAsync(file, Path.GetFileName(file));
                }
            }
        }
    }
}

Log.Information("Written {SourceFile} to {TargetFile}", sourceFilesDirectory, targetGzipFile);