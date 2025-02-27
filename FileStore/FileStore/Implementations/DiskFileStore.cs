﻿using System.Text.Json;

namespace FileStore.Implementations;

public sealed class DiskFileStore : IFileStore
{
    private readonly string _fileStorePath;
    private readonly string _fileStoreMetaDataPath;

    public DiskFileStore(string rootPath, string userID)
    {
        ArgumentException.ThrowIfNullOrEmpty(rootPath);
        ArgumentException.ThrowIfNullOrEmpty(userID);
        // Set up the user specific folder for file storage
        _fileStorePath = Path.Combine(rootPath, userID);
        // Set up the user specific folder for file metadata storage
        _fileStoreMetaDataPath = Path.Combine(rootPath, userID, "METADATA");

        if (!Directory.Exists(_fileStorePath))
            Directory.CreateDirectory(_fileStorePath);

        if (!Directory.Exists(_fileStoreMetaDataPath))
            Directory.CreateDirectory(_fileStoreMetaDataPath);
    }

    public async Task<FileMetaData> GetMetaData(Guid id, CancellationToken token)
    {
        // Build expected path of the file
        var storeFileMetaData = Path.Combine(_fileStoreMetaDataPath, id.ToString());
        if (!File.Exists(storeFileMetaData))
            throw new FileNotFoundException("File not found", id.ToString());
        var meta = JsonSerializer.Deserialize<FileMetaData>(await File.ReadAllTextAsync(storeFileMetaData, token))!;
        return meta;
    }

    public async Task<FileMetaData> Upload(Stream fileStream, string fileName, CancellationToken token)
    {
        // Generate a new identifier
        var id = Guid.CreateVersion7();
        token.ThrowIfCancellationRequested();
        // Build file path. Past here, we cannot cancel
        var storeFile = Path.Combine(_fileStorePath, id.ToString());
        var storeFileMetaData = Path.Combine(_fileStoreMetaDataPath, id.ToString());
        // Write the file data
        await using (var stream = new FileStream(storeFile, FileMode.Create))
            await fileStream.CopyToAsync(stream, CancellationToken.None);
        // Create metadata
        var meta = new FileMetaData(fileName, id, DateTime.UtcNow);
        // Write the file metadata
        await File.WriteAllTextAsync(storeFileMetaData, JsonSerializer.Serialize(meta), token);
        // Return metadata object
        return meta;
    }

    public async Task<bool> Exists(Guid id)
    {
        // Build expected path of the file
        var storeFile = Path.Combine(_fileStorePath, id.ToString());
        return await Task.FromResult(File.Exists(storeFile));
    }

    public Task Delete(Guid id)
    {
        // Build expected path of the file & metadata file
        var storeFile = Path.Combine(_fileStorePath, id.ToString());
        var storeFileMetadata = Path.Combine(_fileStoreMetaDataPath, id.ToString());
        if (!File.Exists(storeFile))
            throw new FileNotFoundException("File not found", id.ToString());
        // Delete file
        File.Delete(storeFile);
        // Delete metadata
        File.Delete(storeFileMetadata);
        return Task.CompletedTask;
    }

    public async Task<Stream> Download(Guid id, CancellationToken token)
    {
        // Build expected path of the file
        var storeFile = Path.Combine(_fileStorePath, id.ToString());
        if (!File.Exists(storeFile))
            throw new FileNotFoundException("File not found", storeFile);
        token.ThrowIfCancellationRequested();
        // Return an async Stream
        return await Task.FromResult(new FileStream(storeFile, FileMode.Open, FileAccess.Read, FileShare.Read, 4096,
            true));
    }
}