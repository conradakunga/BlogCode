using Serilog;
using Stateless;
using Stateless.Graph;

namespace Orders;

public sealed class Call
{
    private readonly StateMachine<Status, Trigger> _stateMachine;
    public string Graph => UmlDotGraph.Format(_stateMachine.GetInfo());
    public Status CurrentStatus => _stateMachine.State;

    public bool IsConnected => _stateMachine.IsInState(Status.Connected);

    public Call() : this(Status.Ready)
    {
    }

    private Call(Status status)
    {
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

        _stateMachine.Configure(Status.Connected)
            .Permit(Trigger.Hold, Status.OnHold)
            .Permit(Trigger.HangUp, Status.Ready)
            .OnEntry(() => Log.Information("Connected..."));

        _stateMachine.Configure(Status.OnHold)
            .PermitIf(Trigger.UnHold, Status.Connected)
            .PermitIf(Trigger.HangUp, Status.Ready)
            .OnEntry(() => Log.Information("Placing On Hold..."));

        _stateMachine.Configure(Status.Ready)
            .OnEntry(() => Log.Information("Hanging Up..."));
    }

    public void Dial()
    {
        // Log.Information("Dialing...");
        _stateMachine.Fire(Trigger.Dial);
    }

    public void HangUp()
    {
        // Log.Information("Hanging Up...");
        _stateMachine.Fire(Trigger.HangUp);
    }

    public void PickUp()
    {
        // Log.Information("Connected...");
        _stateMachine.Fire(Trigger.PickUp);
    }

    public void Hold()
    {
        // Log.Information("Placing On Hold...");
        _stateMachine.Fire(Trigger.Hold);
    }

    public void UnHold()
    {
        // Log.Information("Removing from Hold...");
        _stateMachine.Fire(Trigger.UnHold);
    }
}