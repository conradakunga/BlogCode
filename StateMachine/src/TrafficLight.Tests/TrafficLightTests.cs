using FluentAssertions;

namespace StateMachine.Tests;

public class TrafficLightTests
{
    [Fact]
    public void Lights_Change_Correctly()
    {
        var light = new TrafficLight();
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
}