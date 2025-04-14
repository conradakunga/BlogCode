namespace Calls;

public interface IStreamingService
{
    // Get the current volumn
    byte Volume { get; }
    // Increase the volume by one step
    void IncreaseVolume();
    // Decease the volume by one step
    void DecreaseVolume();
    // Mute the music
    void Mute();
    // Unmute the music
    void Unmute();
}