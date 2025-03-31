using Serilog;
using Stateless;

namespace Calls;

public sealed class Call
{
    // State machine
    private readonly StateMachine<Status, Trigger> _stateMachine;

    // Store our start time for tracking
    private DateTime _startTime;

    // Constant for minimum threshold
    private const int MinimumTimeBeforeHoldInSeconds = 10;
    public Status CurrentStatus => _stateMachine.State;

    public Call(TimeProvider timeProvider) : this(Status.Ready, timeProvider)
    {
    }

    private Call(Status status, TimeProvider timeProvider)
    {
        var provider = timeProvider;
        _stateMachine = new StateMachine<Status, Trigger>(status);

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
            .PermitIf(Trigger.Hold, Status.OnHold,
                () => (timeProvider.GetUtcNow().DateTime - _startTime).TotalSeconds >= MinimumTimeBeforeHoldInSeconds)
            .Permit(Trigger.HangUp, Status.Ready)
            .OnEntry(() =>
            {
                Log.Information("Connected...");
                // Set the start time
                _startTime = provider.GetUtcNow().DateTime;
            });


        _stateMachine.Configure(Status.OnHold)
            .PermitIf(Trigger.UnHold, Status.Connected)
            .PermitIf(Trigger.HangUp, Status.Ready)
            .OnEntry(() => Log.Information("Placing On Hold..."));

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