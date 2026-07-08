using System.Diagnostics;

var info = new ProcessStartInfo
{
    FileName = "ping",
    Arguments = "google.com",
    StartDetached = true,
    UseShellExecute = false
};

// Start the detached process
Process.StartAndForget(info);