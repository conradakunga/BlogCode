using Stateless;
using Stateless.Graph;

namespace Orders;

public sealed class Order
{
    private readonly StateMachine<Status, Trigger> _stateMachine;
    public string Graph => UmlDotGraph.Format(_stateMachine.GetInfo());
    public Status CurrentStatus => _stateMachine.State;

    public Order()
    {
        // Create the state machine, and set the initial state as Incomplete
        _stateMachine = new StateMachine<Status, Trigger>(Status.Incomplete);

        //
        // Configure state machine
        //

        _stateMachine.Configure(Status.Incomplete)
            .Permit(Trigger.CompleteOrder, Status.OrderCompleted);

        _stateMachine.Configure(Status.OrderCompleted)
            .Permit(Trigger.Pay, Status.OrderPaid)
            .Permit(Trigger.Cancel, Status.Canceled);

        _stateMachine.Configure(Status.OrderPaid)
            .Permit(Trigger.Dispatch, Status.Dispatched);

        _stateMachine.Configure(Status.Dispatched)
            .Permit(Trigger.Deliver, Status.Delivered)
            .Permit(Trigger.Reject, Status.Rejected);
    }

    public void CompleteOrder()
    {
        _stateMachine.Fire(Trigger.CompleteOrder);
    }

    public void PayOrder()
    {
        _stateMachine.Fire(Trigger.Pay);
    }

    public void CancelOrder()
    {
        _stateMachine.Fire(Trigger.Cancel);
    }

    public void DispatchOrder()
    {
        _stateMachine.Fire(Trigger.Dispatch);
    }

    public void DeliverOrder()
    {
        _stateMachine.Fire(Trigger.Deliver);
    }

    public void RejectOrder()
    {
        _stateMachine.Fire(Trigger.Reject);
    }
}