namespace FileStore;

public sealed class DiskFileStore
{
    private readonly string _fileStorePath;
    private readonly string _userID;

    public DiskFileStore(string fileStorePath, string userID)
    {
        ArgumentException.ThrowIfNullOrEmpty(fileStorePath);
        ArgumentException.ThrowIfNullOrEmpty(userID);
        _fileStorePath = fileStorePath;
        _userID = userID;
    }

    public async Task<Guid> Upload(Stream fileStream, CancellationToken token)
    {
        // Generate a new identifier
        var id = Guid.CreateVersion7();
        // Check if per-user directory exists, create if not
        var fileStoreUserDirectory = Path.Combine(_fileStorePath, _userID);
        if (!Directory.Exists(fileStoreUserDirectory))
            Directory.CreateDirectory(fileStoreUserDirectory);

        token.ThrowIfCancellationRequested();

        // Build file path. Past here, we cannot cancel
        var fileStorePath = Path.Combine(fileStoreUserDirectory, id.ToString());
        await using (var stream = new FileStream(fileStorePath, FileMode.Create))
            await fileStream.CopyToAsync(stream, CancellationToken.None);

        return id;
    }

    public async Task<bool> Exists(Guid id)
    {
        var fileStorePath = Path.Combine(_fileStorePath, _userID, id.ToString());
        return await Task.FromResult(File.Exists(fileStorePath));
    }

    public async Task<Stream> Download(Guid id, CancellationToken token)
    {
        // Build expected path of the file
        var filePath = Path.Combine(_fileStorePath, _userID, id.ToString());

        if (!File.Exists(filePath))
            throw new FileNotFoundException("File not found", filePath);

        token.ThrowIfCancellationRequested();

        // Return an async Stream
        return await Task.FromResult(new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096,
            true));
    }
}