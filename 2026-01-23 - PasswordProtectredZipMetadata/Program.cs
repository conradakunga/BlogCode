using System.IO;
using System.Reflection;
using ICSharpCode.SharpZipLib.Zip;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console().CreateLogger();

// Extract the current folder where the executable is running
var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

// Set the password (typically this would come from the user)
const string password = "A$tr0nGpA$$w)rDf";

// Construct the full path to the zip file
var targetZipFile = Path.Combine(currentFolder, "PasswordProtected.zip");

using (var fs = File.OpenRead(targetZipFile))
{
    using (var zip = new ZipFile(fs))
    {
        // Set the password
        zip.Password = password;

        // Loop through all the files
        foreach (ZipEntry entry in zip)
        {
            if (entry.IsFile)
            {
                Log.Information("==============================");
                Log.Information("Name: {Name}", entry.Name);
                Log.Information("Compressed Size: {CompressedSize:#,0} bytes", entry.CompressedSize);
                Log.Information("Size: {Size:#,0} bytes", entry.Size);
                Log.Information("Compression Method: {CompressionMethod}", entry.CompressionMethod);
                Log.Information("Crc: {Crc}", entry.Crc);
                Log.Information("Date Time: {DateTime:d MMM yyyy HH:mm}", entry.DateTime);
                Log.Information("Host System: {HostSystem}", entry.HostSystem);
                Log.Information("Version: {Version}", entry.Version);
                Log.Information("Version Made By: {VersionMadeBy}", entry.VersionMadeBy);
                Log.Information("Zip File Index: {ZipFileIndex}", entry.ZipFileIndex);
            }
        }
    }
}