using Microsoft.IO;

public static class StreamManager
{
    public static readonly RecyclableMemoryStreamManager Instance = new();
}