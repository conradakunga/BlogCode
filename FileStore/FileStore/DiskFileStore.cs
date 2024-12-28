namespace FileStore;

public sealed class DiskFileStore
{
    private readonly string _fileStorePath;

    public DiskFileStore(string fileStorePath)
    {
        ArgumentException.ThrowIfNullOrEmpty(fileStorePath);
        _fileStorePath = fileStorePath;
    }

    public async Task<Guid> Upload(Stream fileStream, CancellationToken token)
    {
        // Generate a new identifier
        var id = Guid.CreateVersion7();
        // Write to disk
        var fileStorePath = Path.Combine(_fileStorePath, id.ToString());
        await using (var stream = new FileStream(fileStorePath, FileMode.Create))
        {
            await fileStream.CopyToAsync(stream, token);
        }

        return id;
    }

    public async Task<bool> Exists(Guid id, CancellationToken token)
    {
        var fileStorePath = Path.Combine(_fileStorePath, id.ToString());
        return await Task.FromResult(File.Exists(fileStorePath));
    }

    public async Task<Stream> Download(Guid id, CancellationToken token)
    {
        // Build expected path of the file
        var filePath = Path.Combine(_fileStorePath, id.ToString());

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File not found", filePath);
        }

        token.ThrowIfCancellationRequested();

        // Return an async Stream
        return await Task.FromResult(new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096,
            true));
    }
}