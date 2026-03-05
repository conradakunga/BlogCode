using System.IO.Compression;
using System.Reflection;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console().CreateLogger();

const string sourceZipFileName = "Books.zip";
const string targetFolderName = "ExtractedBooks";

// Extract the current folder where the executable is running
var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
// Construct path to the source zip file
var sourceZipFile = Path.Combine(currentFolder!, sourceZipFileName);
// Construct target path for extraction
var targetFolder = Path.Combine(currentFolder!, targetFolderName);
// Open the zip file and extract file to the target directory 
await ZipFile.ExtractToDirectoryAsync(sourceZipFile, targetFolder);

Log.Information("Written {SourceZipFile} to {TargetTextFile}", sourceZipFileName, targetFolder);