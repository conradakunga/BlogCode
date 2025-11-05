namespace FileShareAccess;

public static class FileHelper
{
    public static bool IsFileLocked(string path)
    {
        FileStream? stream = null;
        try
        {
            // Try to open the file with exclusive read/write access
            stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            return false;
        }
        catch (IOException)
        {
            // IOException occurs if the file is in use
            return true;
        }
        finally
        {
            stream?.Close();
        }
    }
}