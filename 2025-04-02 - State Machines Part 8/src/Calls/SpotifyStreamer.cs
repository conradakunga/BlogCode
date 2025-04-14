namespace Calls;

public class SpotifyStreamer : IStreamingService
{
    public byte Volume { get; private set; } = 5;

    public void IncreaseVolume()
    {
        if (Volume < 10)
            Volume++;
    }

    public void DecreaseVolume()
    {
        if (Volume > 0)
            Volume--;
    }

    public void Mute()
    {
        Volume = 0;
    }

    public void Unmute()
    {
        Volume = 5;
    }
}