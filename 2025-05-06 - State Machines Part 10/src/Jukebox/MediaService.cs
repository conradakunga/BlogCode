namespace Jukebox;

public class MediaService : IMediaService
{
    public async Task<Stream> GetSong(int songNumber)
    {
        // Simulate latency
        await Task.Delay(TimeSpan.FromSeconds(5));
        // Return dummy stream of music
        return new MemoryStream([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]);
    }
}