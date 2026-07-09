using System.IO.Compression;
using System.Reflection;

const string fileName = "war-and-peace.txt";
// Build path to store the files
var targetPath = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory!.FullName;

// ZStandard
await using (var inputStream = File.OpenRead(fileName))
{
    await using (var outputStream = File.Create(Path.Combine(targetPath, "ZStandard")))
    {
        await using (var compressStream = new ZstandardStream(outputStream, CompressionMode.Compress))
        {
            await inputStream.CopyToAsync(compressStream);
        }
    }
}

// Brotli
await using (var inputStream = File.OpenRead(fileName))
{
    await using (var outputStream = File.Create(Path.Combine(targetPath, "Brotli")))
    {
        await using (var compressStream = new BrotliStream(outputStream, CompressionMode.Compress))
        {
            await inputStream.CopyToAsync(compressStream);
        }
    }
}

// Gzip
await using (var inputStream = File.OpenRead(fileName))
{
    await using (var outputStream = File.Create(Path.Combine(targetPath, "Gzip")))
    {
        await using (var compressStream = new GZipStream(outputStream, CompressionMode.Compress))
        {
            await inputStream.CopyToAsync(compressStream);
        }
    }
}

// Deflate
await using (var inputStream = File.OpenRead(fileName))
{
    await using (var outputStream = File.Create(Path.Combine(targetPath, "Deflate")))
    {
        await using (var compressStream = new DeflateStream(outputStream, CompressionMode.Compress))
        {
            await inputStream.CopyToAsync(compressStream);
        }
    }
}