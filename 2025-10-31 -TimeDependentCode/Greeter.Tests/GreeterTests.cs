using AwesomeAssertions;
using GreeterLogic;
using Microsoft.Extensions.Time.Testing;

namespace GreeterTests;

public class GreeterTests
{
    [Theory]
    [InlineData(1, "Good Morning")]
    [InlineData(12, "Good Morning")]
    [InlineData(13, "Good Afternoon")]
    [InlineData(16, "Good Afternoon")]
    [InlineData(17, "Good Evening")]
    [InlineData(20, "Good Evening")]
    [InlineData(21, "Good Night")]
    [InlineData(23, "Good Night")]
    public void Greeter_Returns_Correct_Greeting(int hour, string greeting)
    {
        // Create a fake time provider
        var provider = new FakeTimeProvider();
        // Set the time based on passed values (hour)
        provider.SetUtcNow(new DateTime(2024, 1, 1, hour, 1, 0));
        // Create instance of system under test
        var sut = new Greeter(provider);
        // Assert result
        sut.Greet().Should().Be(greeting);
    }
}