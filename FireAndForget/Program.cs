using System.Diagnostics;


//
// The old way
//

Process.Start(new ProcessStartInfo
{
    FileName = "ping",
    Arguments = "-v google.com",
    CreateNoWindow = true
});

//
// The new way
//

Process.StartAndForget("ping", ["-v", "conradakunga.com"]);