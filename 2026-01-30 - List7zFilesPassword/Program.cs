using System.IO;
using System.Reflection;
using CliWrap;
using CliWrap.Buffered;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console().CreateLogger();

// Extract the current folder where the executable is running
var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

// Construct the full path to the zip file
var source7ZipFile = Path.Combine(currentFolder, "Books.7z");

// Archive password
const string password = "A$tr0ngP@ssw0rD";

// Path to 7zip executable
const string executablePath = "/opt/homebrew/bin/7zz";

var result = await Cli.Wrap(executablePath) // Set the path to the executable
    .WithArguments(args => args
            .Add("l") //Specify to list files in the archive
            .Add(source7ZipFile) // Source zip file
            .Add($"-p{password}") // The archive password
    )
    .ExecuteBufferedAsync();

// Check if the process succeeded
if (result.ExitCode != 0)
    Log.Error("7-Zip failed: {Message}", result.StandardError);
else
    Log.Information("Listing of files in {SourceZipFile} {Message}", source7ZipFile, result.StandardOutput);