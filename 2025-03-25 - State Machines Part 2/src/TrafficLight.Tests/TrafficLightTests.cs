using FluentAssertions;
using Microsoft.Extensions.Time.Testing;
using StateMachineSample;

namespace StateMachine.Tests;

public class TrafficLightTests
{
    [Theory]
    [InlineData(6, 00)]
    [InlineData(12, 00)]
    [InlineData(11, 59)]
    public void Lights_Change_Correctly_During_The_Day(int hour, int minute)
    {
        var currentDate = DateTime.Now;
        var provider = new FakeTimeProvider();
        provider.SetUtcNow(new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, hour, minute, 0));
        var light = new TrafficLight(provider);
        light.CurrentStatus.Should().Be(Status.Red);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.AmberFromRed);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.Green);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.AmberFromGreen);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.Red);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.AmberFromRed);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(5, 59)]
    public void Lights_Change_Correctly_During_The_Night(int hour, int minute)
    {
        var currentDate = DateTime.Now;
        var provider = new FakeTimeProvider();
        provider.SetUtcNow(new DateTimeOffset(currentDate.Year, currentDate.Month, currentDate.Day, hour, minute, 0,
            TimeSpan.Zero));
        var light = new TrafficLight(provider);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.AmberFromRed);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.AmberFromRed);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.AmberFromRed);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.AmberFromRed);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.AmberFromRed);
    }

    [Theory]
    [InlineData(1, 1, 12, 0)]
    [InlineData(1, 1, 1, 0)]
    [InlineData(25, 12, 12, 0)]
    [InlineData(25, 12, 1, 0)]
    [InlineData(26, 12, 12, 0)]
    [InlineData(26, 12, 1, 0)]
    public void Lights_Change_Correctly_On_Public_Holidays(int day, int month, int hour, int minute)
    {
        var currentDate = DateTime.Now;
        var provider = new FakeTimeProvider();
        provider.SetUtcNow(new DateTimeOffset(currentDate.Year, month, day, hour, minute, 0, TimeSpan.Zero));
        var light = new TrafficLight(provider);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.AmberFromRed);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.AmberFromRed);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.AmberFromRed);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.AmberFromRed);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.AmberFromRed);
    }

    [Theory]
    [InlineData(Status.AmberFromRed, Status.Green)]
    [InlineData(Status.Green, Status.AmberFromGreen)]
    [InlineData(Status.AmberFromGreen, Status.Red)]
    public void Lights_State_Is_Loaded_Correctly(Status initialState, Status nextState)
    {
        var currentDate = DateTime.Now;
        var provider = new FakeTimeProvider();
        // Set time to midday
        provider.SetUtcNow(new DateTimeOffset(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0,
            TimeSpan.Zero));
        var light = new TrafficLight(provider, initialState);
        light.CurrentStatus.Should().Be(initialState);
        light.Transition();
        light.CurrentStatus.Should().Be(nextState);
    }
}