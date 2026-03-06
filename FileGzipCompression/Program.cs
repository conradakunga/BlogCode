using System.IO.Compression;
using System.Reflection;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

const string fileName = "war-and-peace";

// Extract the current folder where the executable is running
var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
var sourceFile = Path.Combine(currentFolder, $"{fileName}.txt");
var targetFile = Path.Combine(currentFolder, $"{fileName}.gz");

// Create a gzip stream for the target
using (var gzip = new GZipStream(File.Create(targetFile), CompressionLevel.Optimal))
{
    // Read the source file and copy into the gzip stream
    using (var input = File.OpenRead(sourceFile))
    {
        input.CopyTo(gzip);
    }
}

Log.Information("Written {SourceFile} to {TargetFile}", sourceFile, targetFile);