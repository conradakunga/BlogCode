namespace Jukebox;

public interface IMediaService
{
    public Task<Stream> GetSong(int songNumber);
}