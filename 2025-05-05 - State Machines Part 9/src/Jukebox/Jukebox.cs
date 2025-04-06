using Stateless;

namespace Jukebox;

public sealed class Jukebox
{
    public Status CurrentStatus => _stateMachine.State;

    // State machine
    private readonly StateMachine<Status, Trigger> _stateMachine;

    public Jukebox(IMediaService service)
    {
        _stateMachine = new StateMachine<Status, Trigger>(Status.Ready);
        var mediaPlayer = new MediaPlayer();

        //
        // Configure state machine
        //
        _stateMachine.Configure(Status.Ready)
            .Permit(Trigger.Play, Status.Playing);

        _stateMachine.Configure(Status.Playing)
            .Permit(Trigger.Stop, Status.Ready)
            .Permit(Trigger.Pause, Status.Paused)
            .OnEntryAsync(async () =>
            {
                // Get a random song between 0 and 1000
                var musicStream = await service.GetSong(Random.Shared.Next(1000));
                // Play the music
                mediaPlayer.Play(musicStream);
            });

        _stateMachine.Configure(Status.Paused)
            .Permit(Trigger.Play, Status.Playing)
            .Permit(Trigger.Stop, Status.Ready)
            .OnEntry(() =>
            {
                // Pause the music
                mediaPlayer.Pause();
            });
    }

    public async Task Play()
    {
        await _stateMachine.FireAsync(Trigger.Play);
    }

    public void Pause()
    {
        _stateMachine.Fire(Trigger.Pause);
    }

    public void Stop()
    {
        _stateMachine.Fire(Trigger.Stop);
    }
}