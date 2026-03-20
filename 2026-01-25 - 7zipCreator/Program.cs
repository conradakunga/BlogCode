using System.Reflection;
using CliWrap;
using CliWrap.Buffered;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console().CreateLogger();

// Extract the current folder where the executable is running
var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

// Construct the full path to the source files
var folderWithBooks = Path.Combine(currentFolder, "Books");

// Construct the full path to the zip file
var target7ZipFile = Path.Combine(currentFolder, "Books.7z");

// Path to 7zip executable
const string executablePath = "/opt/homebrew/bin/7zz";

// Delete 7zip file if it exists
if (File.Exists(target7ZipFile))
    File.Delete(target7ZipFile);

var result = await Cli.Wrap(executablePath) // Set the path to the executable
    .WithArguments(args => args
            .Add("a") //Specify to create an archive
            .Add("-t7z") // Specify the target format - 7z
            .Add(target7ZipFile) // Taget file name
            .Add($"{folderWithBooks}") // The files in the source folder
            .Add("-mx=9") // max compression
    )
    .ExecuteBufferedAsync();

// Check if the process succeeded
if (result.ExitCode != 0)
    Log.Error("7-Zip failed: {Message}", result.StandardError);
else
    Log.Information("Written files in {SourceFiles} to {Target7ZipFile} {Message}", folderWithBooks, target7ZipFile,
        result.StandardOutput);