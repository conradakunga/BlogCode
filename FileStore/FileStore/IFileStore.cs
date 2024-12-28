namespace FileStore;

public interface IFileStore
{
    Task<FileMetaData> GetMetaData(Guid id, CancellationToken token);
    Task<FileMetaData> Upload(Stream fileStream, string fileName, CancellationToken token);
    Task<bool> Exists(Guid id);
    Task Delete(Guid id);
    Task<Stream> Download(Guid id, CancellationToken token);
}