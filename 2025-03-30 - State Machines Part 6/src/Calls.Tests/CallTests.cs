using FluentAssertions;
using Orders;
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

    [Fact]
    public void Call_Transitions_Correctly()
    {
        var call = new Call();
        call.Dial();
        _output.Output.Should().EndWith("Ringing...\n");
        call.PickUp();
        _output.Output.Should().EndWith("Connected...\n");
        call.Hold();
        _output.Output.Should().EndWith("Placing On Hold...\n");
        call.HangUp();
        _output.Output.Should().EndWith("Hanging Up...\n");
    }

    [Fact]
    public void Call_Transitions_Correctly_From_Hold_To_Connected()
    {
        var call = new Call();
        call.Dial();
        _output.Output.Should().EndWith("Ringing...\n");
        call.PickUp();
        _output.Output.Should().EndWith("Connected...\n");
        call.Hold();
        _output.Output.Should().EndWith("Placing On Hold...\n");
        call.UnHold();
        _output.Output.Should().EndWith("Connected...\n");
        call.HangUp();
    }
}
