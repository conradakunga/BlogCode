using System.Diagnostics;
using Serilog;


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

//
// The old way
//

var startInfo = new ProcessStartInfo
{
    FileName = "pwd",
    Arguments = "",
    RedirectStandardOutput = true,
    RedirectStandardError = true,
    UseShellExecute = false,
    CreateNoWindow = true
};

using (var process = Process.Start(startInfo))
{
    await process.WaitForExitAsync();

    if (process.ExitCode == 0)
        Log.Information("Success!");

    else
        Log.Error("Failed!");
}

//
// The new way
//

var result = await Process.RunAsync("pwd", ["-l"]);
if (result.ExitCode == 0)
    Log.Information("Success");
else
    Log.Error("Failure");