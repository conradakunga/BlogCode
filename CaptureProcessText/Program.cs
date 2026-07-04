using System.Diagnostics;
using Serilog;


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

//
// The old way
//

//
// var startInfo = new ProcessStartInfo
// {
//     FileName = "pwd",
//     Arguments = "",
//     RedirectStandardOutput = true,
//     RedirectStandardError = true,
//     UseShellExecute = false,
//     CreateNoWindow = true
// };
//
// using (var process = Process.Start(startInfo))
// {
//     var output = await process.StandardOutput.ReadToEndAsync();
//     var error = await process.StandardError.ReadToEndAsync();
//
//     await process.WaitForExitAsync();
//
//     if (process.ExitCode == 0)
//         Log.Information(output);
//     else
//         Log.Error(error);
// }

//
// The new way
//

var result = await Process.RunAndCaptureTextAsync("pwd", ["-l"]);
if (result.ExitStatus.ExitCode == 0)
    Log.Information(result.StandardOutput);
else
    Log.Error(result.StandardError);