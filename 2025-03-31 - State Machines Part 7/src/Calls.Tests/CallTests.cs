using FluentAssertions;
using Microsoft.Extensions.Time.Testing;
using Serilog;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Calls.Tests;

public class CallTests
{
    private readonly TestOutputHelper _output;

    public CallTests(ITestOutputHelper output)
    {
        _output = (TestOutputHelper)output;
        // Configure logger to tap into test output
        Log.Logger = new LoggerConfiguration()
            .WriteTo.TestOutput(output)
            .CreateLogger();
    }

    [Theory]
    [InlineData(10.0)]
    [InlineData(10.1)]
    [InlineData(40)]
    public void Call_Is_Placed_OnHold_After_Ten_Seconds(decimal seconds)
    {
        var provider = new FakeTimeProvider();
        provider.SetUtcNow(DateTime.UtcNow);
        var call = new Call(provider);
        call.Dial();
        _output.Output.Should().EndWith("Ringing...\n");
        call.PickUp();
        _output.Output.Should().EndWith("Connected...\n");
        // Advance the time by 10 seconds
        provider.Advance(TimeSpan.FromSeconds((double)seconds));
        var ex = Record.Exception(() => call.Hold());
        ex.Should().BeNull();
        // Check status is on hold
        call.CurrentStatus.Should().Be(Status.OnHold);
    }

    [Theory]
    [InlineData(9.0)]
    [InlineData(9.9)]
    [InlineData(0)]
    [InlineData(1)]
    public void Call_Placing_OnHold_Fails_Before_Threshold_Seconds(decimal seconds)
    {
        var provider = new FakeTimeProvider();
        provider.SetUtcNow(DateTime.UtcNow);
        var call = new Call(provider);
        call.Dial();
        _output.Output.Should().EndWith("Ringing...\n");
        call.PickUp();
        _output.Output.Should().EndWith("Connected...\n");
        // Advance the time by 9 seconds
        provider.Advance(TimeSpan.FromSeconds((double)seconds));
        var ex = Record.Exception(() => call.Hold());
        ex.Should().BeOfType<InvalidOperationException>();
    }
}