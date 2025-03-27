using System.Diagnostics;
using FluentAssertions;
using Orders;

namespace StateMachine.Tests;

public class OrderTests
{
    [Fact]
    public void Delivered_Order_State_TransitionsCorrectly()
    {
        var order = new Order();
        order.CurrentStatus.Should().Be(Status.Incomplete);
        order.CompleteOrder();
        order.CurrentStatus.Should().Be(Status.OrderCompleted);
        order.PayOrder();
        order.CurrentStatus.Should().Be(Status.OrderPaid);
        order.DispatchOrder();
        order.CurrentStatus.Should().Be(Status.Dispatched);
        order.DeliverOrder();
        order.CurrentStatus.Should().Be(Status.Delivered);
    }

    [Fact]
    public void Rejected_Order_State_TransitionsCorrectly()
    {
        var order = new Order();
        order.CurrentStatus.Should().Be(Status.Incomplete);
        order.CompleteOrder();
        order.CurrentStatus.Should().Be(Status.OrderCompleted);
        order.PayOrder();
        order.CurrentStatus.Should().Be(Status.OrderPaid);
        order.DispatchOrder();
        order.CurrentStatus.Should().Be(Status.Dispatched);
        order.RejectOrder();
        order.CurrentStatus.Should().Be(Status.Rejected);
    }

    [Fact]
    public void Canceled_Order_State_TransitionsCorrectly()
    {
        var order = new Order();
        order.CurrentStatus.Should().Be(Status.Incomplete);
        order.CompleteOrder();
        order.CurrentStatus.Should().Be(Status.OrderCompleted);
        order.CancelOrder();
        order.CurrentStatus.Should().Be(Status.Canceled);
    }

    [Fact]
    public void New_Order_Should_Not_Be_Deliverable()
    {
        var order = new Order();
        order.CurrentStatus.Should().Be(Status.Incomplete);
        var ex = Record.Exception(() => order.DeliverOrder());
        ex.Should().BeOfType<InvalidOperationException>();
    }

    [Fact]
    public void New_Order_Should_Not_Be_Payable()
    {
        var order = new Order();
        order.CurrentStatus.Should().Be(Status.Incomplete);
        var ex = Record.Exception(() => order.PayOrder());
        ex.Should().BeOfType<InvalidOperationException>();
    }

    [Fact]
    public void New_Order_Should_Not_Be_Rejectable()
    {
        var order = new Order();
        order.CurrentStatus.Should().Be(Status.Incomplete);
        var ex = Record.Exception(() => order.RejectOrder());
        ex.Should().BeOfType<InvalidOperationException>();
    }

    [Fact]
    public void New_Order_Should_Not_Be_Cancelable()
    {
        var order = new Order();
        order.CurrentStatus.Should().Be(Status.Incomplete);
        var ex = Record.Exception(() => order.CancelOrder());
        ex.Should().BeOfType<InvalidOperationException>();
    }
    [Fact]
    public void New_Order_Should_Not_Be_Dispatchable()
    {
        var order = new Order();
        order.CurrentStatus.Should().Be(Status.Incomplete);
        var ex = Record.Exception(() => order.DispatchOrder());
        ex.Should().BeOfType<InvalidOperationException>();
    }
}