using Serilog;
using Stateless;
using Stateless.Graph;

namespace MediaPlayer;

public class MediaPlayer : IMediaPlayer
{
    private int _position = 0;
    private readonly StateMachine<State, Trigger> _stateMachine;
    public State CurrentState => _stateMachine.State;

    public MediaPlayer()
    {
        _stateMachine = new StateMachine<State, Trigger>(State.Initializing);

        _stateMachine.Configure(State.Initializing)
            .Permit(Trigger.Initialize, State.Ready);

        _stateMachine.Configure(State.Ready)
            .Permit(Trigger.Play, State.Playing)
            .OnEntryAsync(async () =>
            {
                // This awways fires on transition
                await Task.Delay(TimeSpan.FromSeconds(1));
                Log.Information("Ready...");
            })
            .OnActivateAsync(async () =>
            {
                // This only fires when invoked from Startup
                await Task.Delay(TimeSpan.FromSeconds(1));
                Log.Information("Loading media & position...");
            });

        _stateMachine.Configure(State.Playing)
            .Permit(Trigger.Pause, State.Paused)
            .Permit(Trigger.Stop, State.Ready)
            .OnEntry(() =>
            {
                // Play media
                Log.Information("Playing..");
                _position++;
            });

        _stateMachine.Configure(State.Paused)
            .Permit(Trigger.Resume, State.Playing)
            .Permit(Trigger.Stop, State.Ready)
            .OnEntry(() =>
            {
                // Pause
                Log.Information("Pause...");
            });
    }

    public async Task Startup()
    {
        await _stateMachine.FireAsync(Trigger.Initialize);
        await _stateMachine.ActivateAsync();
    }

    public async Task ShutDown()
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        Log.Information("Saving position {Position} to storage ...", _position);
    }

    public async Task Play()
    {
        await _stateMachine.FireAsync(Trigger.Play);
    }

    public async Task Stop()
    {
        await _stateMachine.FireAsync(Trigger.Stop);
    }

    public async Task Pause()
    {
        await _stateMachine.FireAsync(Trigger.Pause);
    }

    public async Task Resume()
    {
        await _stateMachine.FireAsync(Trigger.Resume);
    }
}