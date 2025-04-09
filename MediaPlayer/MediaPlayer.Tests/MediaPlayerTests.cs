using FluentAssertions;
using Serilog;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace MediaPlayer.Tests;

public class MediaPlayerTests
{
    private readonly TestOutputHelper _output;

    public MediaPlayerTests(ITestOutputHelper output)
    {
        _output = (TestOutputHelper)output;
        // Configure logger to tap into test output
        Log.Logger = new LoggerConfiguration()
            .WriteTo.TestOutput(output)
            .CreateLogger();
    }

    [Fact]
    public async Task Media_Player_Transitions_Correctly()
    {
        var mediaPlayer = new MediaPlayer();
        mediaPlayer.CurrentState.Should().Be(State.Initializing);
        await mediaPlayer.Startup();
        _output.Output.Should().EndWith("Loading media & position...\n");
        mediaPlayer.CurrentState.Should().Be(State.Ready);
        await mediaPlayer.Play();
        mediaPlayer.CurrentState.Should().Be(State.Playing);
        await mediaPlayer.Pause();
        mediaPlayer.CurrentState.Should().Be(State.Paused);
        await mediaPlayer.Resume();
        mediaPlayer.CurrentState.Should().Be(State.Playing);
        await mediaPlayer.Stop();
        mediaPlayer.CurrentState.Should().Be(State.Ready);
        _output.Output.Should().EndWith("Ready...\n");
    }
}