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
    public async Task Jukebox_Transitions_To_Playing_After_Ready_When_Played()
    {
        var service = new MediaService();
        var jb = new Jukebox(service);
        await jb.Play();
        jb.CurrentStatus.Should().Be(Status.Playing);
    }

    [Fact]
    public async Task Jukebox_Transitions_To_Paused_After_Playing_When_Paused()
    {
        var service = new MediaService();
        var jb = new Jukebox(service);
        await jb.Play();
        jb.Pause();
        jb.CurrentStatus.Should().Be(Status.Paused);
    }

    [Fact]
    public async Task Jukebox_Transitions_To_Ready_After_Playing_When_Stopped()
    {
        var service = new MediaService();
        var jb = new Jukebox(service);
        await jb.Play();
        jb.Stop();
        jb.CurrentStatus.Should().Be(Status.Ready);
    }

    [Fact]
    public async Task Jukebox_Transitions_To_Ready_After_Paused_When_Stopped()
    {
        var service = new MediaService();
        var jb = new Jukebox(service);
        await jb.Play();
        jb.Pause();
        jb.Stop();
        jb.CurrentStatus.Should().Be(Status.Ready);
    }

    [Fact]
    public void Jukebox_Does_Not_Transition_When_Stopped_After_Initialization()
    {
        var service = new MediaService();
        var jb = new Jukebox(service);
        var ex = Record.Exception(() => jb.Stop());
        ex.Should().BeOfType<InvalidOperationException>();
    }
}