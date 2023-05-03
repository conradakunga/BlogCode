using FluentAssertions;
using Greeter.Logic;

namespace Greeter.Tests;

public class GreeterTests
{
    [Fact]
    public void Morning_Greeting_Is_Returned_Correctly()
    {
        var oneAm = new DateTime(2023, 1, 1, 1, 0, 0);
        var clock = new FakeClock(oneAm);
        var greeter = new Logic.Greeter(clock);
        greeter.Greet().Should().Be("Good Morning");
    }

    [Fact]
    public void Afternoons_Greeting_Is_Returned_Correctly()
    {
        var onePm = new DateTime(2023, 1, 1, 13, 0, 0);
        var clock = new FakeClock(onePm);
        var greeter = new Logic.Greeter(clock);
        greeter.Greet().Should().Be("Good Afternoon");
    }

    [Fact]
    public void Evening_Greeting_Is_Returned_Correctly()
    {
        var sixPm = new DateTime(2023, 1, 1, 18, 0, 0);
        var clock = new FakeClock(sixPm);
        var greeter = new Logic.Greeter(clock);
        greeter.Greet().Should().Be("Good Evening");
    }

    [Fact]
    public void Night_Greeting_Is_Returned_Correctly()
    {
        var ninePm = new DateTime(2023, 1, 1, 21, 0, 0);
        var clock = new FakeClock(ninePm);
        var greeter = new Logic.Greeter(clock);
        greeter.Greet().Should().Be("Good Night");
    }
}