using Serilog;
using Stateless;

namespace Calls;

public sealed class Call
{
    private readonly IStreamingService _service;

    public int MusicVolume => _service.Volume;

    // State machine
    private readonly StateMachine<Status, Trigger> _stateMachine;

    public Call(IStreamingService service) : this(Status.Ready, service)
    {
    }

    private Call(Status status, IStreamingService service)
    {
        _service = service;
        _stateMachine = new StateMachine<Status, Trigger>(status);
        service.Mute();

        //
        // Configure state machine
        //
        _stateMachine.Configure(Status.Ready)
            .Permit(Trigger.Dial, Status.Ringing);

        _stateMachine.Configure(Status.Ringing)
            .Permit(Trigger.PickUp, Status.Connected)
            .Permit(Trigger.HangUp, Status.Ready)
            .OnEntry(() => Log.Information("Ringing..."));

        // Only allow transition of the time since start time is greater than or
        // equal to the threshold (10 seconds). This is by capturing the current time
        // at the point of requested state change and comparing with the start time

        _stateMachine.Configure(Status.Connected)
            .Permit(Trigger.Hold, Status.OnHold)
            .Permit(Trigger.HangUp, Status.Ready)
            .OnEntry(() => { Log.Information("Connected..."); });


        _stateMachine.Configure(Status.OnHold)
            .PermitIf(Trigger.UnHold, Status.Connected)
            .PermitIf(Trigger.HangUp, Status.Ready)
            .OnEntry(() =>
                {
                    Log.Information("Placing On Hold...");
                    Log.Information("Un-muting streamer currently at volume {Volume}...", service.Volume);
                    service.Unmute();
                }
            ).OnExit(() =>
            {
                Log.Information("Exiting hold...");
                Log.Information("Muting streamer currently at volume {Volume}... ...", service.Volume);
                service.Mute();
            });

        _stateMachine.Configure(Status.Ready)
            .OnEntry(() => Log.Information("Hanging Up..."));
    }

    public void Dial()
    {
        _stateMachine.Fire(Trigger.Dial);
    }

    public void HangUp()
    {
        _stateMachine.Fire(Trigger.HangUp);
    }

    public void PickUp()
    {
        _stateMachine.Fire(Trigger.PickUp);
    }

    public void Hold()
    {
        _stateMachine.Fire(Trigger.Hold);
    }

    public void UnHold()
    {
        _stateMachine.Fire(Trigger.UnHold);
    }
}