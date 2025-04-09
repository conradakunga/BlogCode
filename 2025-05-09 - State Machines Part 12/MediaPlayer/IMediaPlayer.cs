namespace MediaPlayer;

public interface IMediaPlayer
{
    Task Startup();
    Task ShutDown();
    Task Play();
    Task Stop();
    Task Pause();
    Task Resume();
}