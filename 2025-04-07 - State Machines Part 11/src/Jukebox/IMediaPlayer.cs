namespace Jukebox;

public interface IMediaPlayer
{
    void Play(Stream song);
    void Pause();
    void Resume();
}