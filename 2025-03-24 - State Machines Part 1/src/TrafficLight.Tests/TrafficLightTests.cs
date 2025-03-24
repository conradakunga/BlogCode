using FluentAssertions;
using Microsoft.Extensions.Time.Testing;

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
        light.CurrentStatus.Should().Be(Status.Amber);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.Green);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.Amber);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.Red);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.Amber);
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
        light.CurrentStatus.Should().Be(Status.Amber);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.Amber);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.Amber);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.Amber);
        light.Transition();
        light.CurrentStatus.Should().Be(Status.Amber);
    }
}