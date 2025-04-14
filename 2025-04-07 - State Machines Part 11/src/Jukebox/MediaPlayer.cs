using Serilog;

namespace Jukebox;

public class MediaPlayer : IMediaPlayer
{
    public void Play(Stream song)
    {
        // Play the song 
        Log.Information("Playing the song");
    }

    public void Pause()
    {
        // Pause the song
        Log.Information("Pausing the song");
    }

    public void Resume()
    {
        // Resuming the song play
        Log.Information("Resuming play");
    }
}