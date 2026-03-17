using System;
using System.IO;
using System.Reflection;
using ICSharpCode.SharpZipLib.Zip;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console().CreateLogger();

// Extract the current folder where the executable is running
var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

// Set the folder with the input files
var folderWithFiles = Path.Combine(currentFolder, "Books");

// Construct the full path to the zip file
var zipFile = Path.Combine(currentFolder, "PasswordProtected.zip");

// Set the password (typically this would come from the user)
const string password = "A$tr0nGpA$$w)rD";

await using (var fs = File.Create(zipFile))
{
    await using (var zipStream = new ZipOutputStream(fs))
    {
        // Set the desired compression level
        zipStream.SetLevel(9);

        // Set the password
        zipStream.Password = password;

        // Loop through the files to be added
        foreach (var file in Directory.GetFiles(folderWithFiles))
        {
            string entryName = Path.GetRelativePath(currentFolder, file);

            Log.Information("Adding {File} to archive", entryName);

            // Create a ZipEntry
            var entry = new ZipEntry(entryName)
            {
                // Set the date of last modification
                DateTime = DateTime.Now
            };

            // Add the entry to the stream
            zipStream.PutNextEntry(entry);

            // Get the bytes from the file
            byte[] buffer = await File.ReadAllBytesAsync(file);

            // Write to the stream
            zipStream.Write(buffer, 0, buffer.Length);

            // Close the entry stream
            zipStream.CloseEntry();
        }
    }
}

Log.Information("Completed adding files to {TargetFile}", zipFile);