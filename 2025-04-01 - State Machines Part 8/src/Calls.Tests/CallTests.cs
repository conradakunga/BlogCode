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

    [Fact]
    public void Music_Is_Played_On_Hold_And_Muted_After()
    {
        var spotify = new SpotifyStreamer();
        var call = new Call(spotify);
        call.Dial();
        call.PickUp();
        call.MusicVolume.Should().Be(0);
        call.Hold();
        call.MusicVolume.Should().Be(5);
        call.UnHold();
        call.MusicVolume.Should().Be(0);
    }
}