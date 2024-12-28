namespace FileStore;

public sealed class DiskFileStore
{
    private readonly string _fileStorePath;

    public DiskFileStore(string fileStorePath)
    {
        ArgumentException.ThrowIfNullOrEmpty(fileStorePath);
        _fileStorePath = fileStorePath;
    }

    public async Task<Guid> Upload(Stream fileStream, string userID, CancellationToken token)
    {
        // Generate a new identifier
        var id = Guid.CreateVersion7();
        // Check if per-user directory exists, create if not
        var fileStoreUserDirectory = Path.Combine(_fileStorePath, userID);
        if (!Directory.Exists(fileStoreUserDirectory))
            Directory.CreateDirectory(fileStoreUserDirectory);

        token.ThrowIfCancellationRequested();

        // Build file path. Past here, we cannot cancel
        var fileStorePath = Path.Combine(fileStoreUserDirectory, id.ToString());
        await using (var stream = new FileStream(fileStorePath, FileMode.Create))
            await fileStream.CopyToAsync(stream, CancellationToken.None);

        return id;
    }

    public async Task<bool> Exists(Guid id, string userID)
    {
        var fileStorePath = Path.Combine(_fileStorePath, userID, id.ToString());
        return await Task.FromResult(File.Exists(fileStorePath));
    }

    public async Task<Stream> Download(Guid id, string userID, CancellationToken token)
    {
        // Build expected path of the file
        var filePath = Path.Combine(_fileStorePath, userID, id.ToString());

        if (!File.Exists(filePath))
            throw new FileNotFoundException("File not found", filePath);

        token.ThrowIfCancellationRequested();

        // Return an async Stream
        return await Task.FromResult(new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096,
            true));
    }
}