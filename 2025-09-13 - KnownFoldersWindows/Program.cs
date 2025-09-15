using System.Runtime.InteropServices;

var downloadsPath = GetDownloadsPath();
if (downloadsPath is null)
    Console.WriteLine("Could not find downloads path");
else
    Console.WriteLine(downloadsPath);
return;

static string? GetDownloadsPath()
{
    // Define the ID
    var downloadFolderID = new Guid("374DE290-123F-4565-9164-39C4925E467B");
    // Invoke the method 
    SHGetKnownFolderPath(downloadFolderID, 0, IntPtr.Zero, out IntPtr outPath);
    // Retrieve the path
    string? path = Marshal.PtrToStringUni(outPath);
    Marshal.FreeCoTaskMem(outPath);
    return path;
}

[DllImport("shell32.dll")]
static extern int SHGetKnownFolderPath(
    [MarshalAs(UnmanagedType.LPStruct)] Guid rfid,
    uint dwFlags,
    IntPtr hToken,
    out IntPtr ppszPath);