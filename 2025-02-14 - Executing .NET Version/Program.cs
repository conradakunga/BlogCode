using System.Diagnostics;

// Setup our process start info
var startInfo = new ProcessStartInfo
{
    FileName = "dotnet",
    Arguments = "--version",
    RedirectStandardOutput = true,
    UseShellExecute = false,
    CreateNoWindow = true
};

// Create a process
var process = new Process();
process.StartInfo = startInfo;

// Start process
process.Start();
// Read output, and discard the newline
string output = process.StandardOutput.ReadToEnd().Trim();
process.WaitForExit();
// Print 
Console.WriteLine(output);

// Use a simpler way
Console.WriteLine(Environment.Version);