using FluentAssertions;
using Serilog;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Jukebox.Tests;

public class JukeboxTests
{
    private readonly TestOutputHelper _output;

    public JukeboxTests(ITestOutputHelper output)
    {
        _output = (TestOutputHelper)output;
        // Configure logger to tap into test output
        Log.Logger = new LoggerConfiguration()
            .WriteTo.TestOutput(output)
            .CreateLogger();
    }

    [Fact]
    public void Jukebox_Initializes_To_Ready()
    {
        var service = new MediaService();
        var jb = new Jukebox(service);
        jb.CurrentStatus.Should().Be(Status.Ready);
    }

    [Fact]
    public async Task Jukebox_when_stopped_and_played_loads_a_new_song()
    {
        var service = new MediaService();
        var jb = new Jukebox(service);
        await jb.Play();
        _output.Output.Should().EndWith("Playing the song\n");
        jb.CurrentStatus.Should().Be(Status.Playing);
    }
    [Fact]
    public async Task Jukebox_when_paused_and_played_resumes_play()
    {
        var service = new MediaService();
        var jb = new Jukebox(service);
        await jb.Play();
        jb.Pause();
        jb.CurrentStatus.Should().Be(Status.Paused);
        jb.Resume();
        _output.Output.Should().EndWith("Resuming play\n");
        jb.CurrentStatus.Should().Be(Status.Playing);
    }
}