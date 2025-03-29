using FluentAssertions;
using Orders;

namespace Calls.Tests;

public class CallTests
{
    [Fact]
    public void Declined_Call_Transitions_Correctly()
    {
        var call = new Call();
        call.CurrentStatus.Should().Be(Status.Ready);
        call.Dial();
        call.CurrentStatus.Should().Be(Status.Ringing);
        call.HangUp();
        call.CurrentStatus.Should().Be(Status.Ready);
    }

    [Fact]
    public void Picked_Call_Transitions_Correctly()
    {
        var call = new Call();
        call.CurrentStatus.Should().Be(Status.Ready);
        call.Dial();
        call.CurrentStatus.Should().Be(Status.Ringing);
        call.PickUp();
        call.CurrentStatus.Should().Be(Status.Connected);
        call.HangUp();
        call.CurrentStatus.Should().Be(Status.Ready);
    }

    [Fact]
    public void Connected_Call_Transitions_To_Hold_Correctly()
    {
        var call = new Call();
        call.Dial();
        call.PickUp();
        call.Hold();
        call.CurrentStatus.Should().Be(Status.OnHold);
    }

    [Fact]
    public void Call_OnHold_Transitions_On_UnHold_Correctly()
    {
        var call = new Call();
        call.Dial();
        call.PickUp();
        call.Hold();
        call.UnHold();
        call.CurrentStatus.Should().Be(Status.Connected);
    }

    [Fact]
    public void Ready_Invalid_Transitions_Are_Rejected()
    {
        var call = new Call(Status.Ready);
        var ex = Record.Exception(() => call.PickUp());
        ex.Should().BeOfType<InvalidOperationException>();

        ex = Record.Exception(() => call.Hold());
        ex.Should().BeOfType<InvalidOperationException>();

        ex = Record.Exception(() => call.UnHold());
        ex.Should().BeOfType<InvalidOperationException>();

        ex = Record.Exception(() => call.HangUp());
        ex.Should().BeOfType<InvalidOperationException>();
    }

    [Fact]
    public void Ringing_Invalid_Transitions_Are_Rejected()
    {
        var call = new Call(Status.Ringing);

        var ex = Record.Exception(() => call.Dial());
        ex.Should().BeOfType<InvalidOperationException>();

        ex = Record.Exception(() => call.UnHold());
        ex.Should().BeOfType<InvalidOperationException>();

        ex = Record.Exception(() => call.Hold());
        ex.Should().BeOfType<InvalidOperationException>();
    }

    [Fact]
    public void Connected_Invalid_Transitions_Are_Rejected()
    {
        var call = new Call(Status.Connected);
        var ex = Record.Exception(() => call.PickUp());
        ex.Should().BeOfType<InvalidOperationException>();


        ex = Record.Exception(() => call.Dial());
        ex.Should().BeOfType<InvalidOperationException>();
    }

    [Fact]
    public void OnHold_Invalid_Transitions_Are_Rejected()
    {
        var call = new Call(Status.OnHold);
        var ex = Record.Exception(() => call.PickUp());
        ex.Should().BeOfType<InvalidOperationException>();

        ex = Record.Exception(() => call.Dial());
        ex.Should().BeOfType<InvalidOperationException>();
    }

    [Fact]
    public void OnHold_Status_Is_Connected()
    {
        var call = new Call(Status.Ready);
        call.Dial();
        call.PickUp();
        call.IsConnected.Should().BeTrue();
        call.Hold();
        call.CurrentStatus.Should().Be(Status.OnHold);
        call.IsConnected.Should().BeTrue();
    }
}