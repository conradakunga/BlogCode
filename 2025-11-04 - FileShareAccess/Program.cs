// Get a temp file name

using FileShareAccess;

var tempFile = Path.GetTempFileName();

// Open the file exclusively for read
using (_ = File.Open(tempFile, FileMode.Open, FileAccess.Read, FileShare.None))
{
    try
    {
        // Check if we can get write access
        if (FileHelper.IsFileLocked(tempFile))
        {
            Console.WriteLine($"Cannot get write access to file {tempFile}");
            return;
        }

        // Write some data to the file
        File.AppendAllText(tempFile, "this is some test data");
        // Read the contents
        var contents = File.ReadAllText(tempFile);
        // Print to console
        Console.WriteLine(contents);
    }
    finally
    {
        // Cleanup
        File.Delete(tempFile);
    }
}