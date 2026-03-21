using System.Reflection;
using CliWrap;
using CliWrap.Buffered;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console().CreateLogger();

// Extract the current folder where the executable is running
var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

// Construct folder to the input files
var folderWithBooks = Path.Combine(currentFolder, "Books");

// Construct the full path to the target archives
var targetArchiveWithFolder = Path.Combine(currentFolder, "BooksWithFolder.7z");
var targetArchiveWithFiles = Path.Combine(currentFolder, "BooksWithFiles.7z");

// Path to 7zip executable
const string executablePath = "/opt/homebrew/bin/7zz";

// Create the first archive, with the folder
var result = await Cli.Wrap(executablePath) // Set the path to the executable
    .WithArguments(args => args
            .Add("a") //Specify to create an archive
            .Add("-t7z") // Specify the target format - 7z
            .Add(targetArchiveWithFolder) // Target file name
            .Add($"{folderWithBooks}") // The files in the source folder
            .Add("-mhe=on") // encrypt file names
            .Add("-mx=9") // max compression
    )
    .ExecuteBufferedAsync();

// Check if the process succeeded
if (result.ExitCode != 0)
    Log.Error("7-Zip failed: {Message}", result.StandardError);
else
    Log.Information("Added folder to {File}", targetArchiveWithFolder);


// Create the second archive, with the files
result = await Cli.Wrap(executablePath) // Set the path to the executable
    .WithArguments(args => args
            .Add("a") //Specify to create an archive
            .Add("-t7z") // Specify the target format - 7z
            .Add(targetArchiveWithFiles) // Target file name
            .Add($"{folderWithBooks}//*") // The files in the source folder
            .Add("-mhe=on") // encrypt file names
            .Add("-mx=9") // max
    )
    .ExecuteBufferedAsync();

// Check if the process succeeded
if (result.ExitCode != 0)
    Log.Error("7-Zip failed: {Message}", result.StandardError);
else
    Log.Information("Added folder to {File}", targetArchiveWithFolder);

//
// Extract both archives
//

result = await Cli.Wrap(executablePath) // Set the path to the executable
    .WithArguments(args => args
            .Add("l") //Specify to list archive contents
            .Add(targetArchiveWithFolder) // Source zip file
    )
    .ExecuteBufferedAsync();

// Check if the process succeeded
if (result.ExitCode != 0)
    Log.Error("7-Zip failed: {Message}", result.StandardError);
else
    Log.Information("Files In {File} (Folder) - {Listing}", targetArchiveWithFolder, result.StandardOutput);

result = await Cli.Wrap(executablePath) // Set the path to the executable
    .WithArguments(args => args
            .Add("l") //Specify to list archive contents
            .Add(targetArchiveWithFiles) // Source zip file
    )
    .ExecuteBufferedAsync();

// Check if the process succeeded
if (result.ExitCode != 0)
    Log.Error("7-Zip failed: {Message}", result.StandardError);
else
    Log.Information("Files In {File} (Folder) - {Listing}", targetArchiveWithFolder, result.StandardOutput);