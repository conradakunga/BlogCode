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

    public Call(Status status)
    {
        _stateMachine = new StateMachine<Status, Trigger>(status);

        //
        // Configure state machine
        //

        _stateMachine.Configure(Status.Ready)
            .Permit(Trigger.Dial, Status.Ringing);

        _stateMachine.Configure(Status.Ringing)
            .Permit(Trigger.PickUp, Status.Connected)
            .Permit(Trigger.HangUp, Status.Ready);

        _stateMachine.Configure(Status.Connected)
            .Permit(Trigger.Hold, Status.OnHold)
            .Permit(Trigger.HangUp, Status.Ready);

        _stateMachine.Configure(Status.OnHold)
            .SubstateOf(Status.Connected)
            .PermitIf(Trigger.UnHold, Status.Connected, () => CurrentStatus == Status.OnHold)
            .PermitIf(Trigger.HangUp, Status.Ready, () => CurrentStatus == Status.OnHold);
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