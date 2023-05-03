using FluentAssertions;

namespace Greeter.Tests;

public class GreeterTests
{
    [Fact]
    public void Morning_Greeting_Is_Returned_Correctly()
    {
        var greeter = new Logic.Greeter();
        var oneAm = new DateTime(2023, 1, 1, 1, 0, 0);
        greeter.Greet(oneAm).Should().Be("Good Morning");
    }

    [Fact]
    public void Afternoons_Greeting_Is_Returned_Correctly()
    {
        var greeter = new Logic.Greeter();
        var onePm = new DateTime(2023, 1, 1, 13, 0, 0);
        greeter.Greet(onePm).Should().Be("Good Afternoon");
    }

    [Fact]
    public void Evening_Greeting_Is_Returned_Correctly()
    {
        var greeter = new Logic.Greeter();
        var sixPm = new DateTime(2023, 1, 1, 18, 0, 0);
        greeter.Greet(sixPm).Should().Be("Good Evening");
    }

    [Fact]
    public void Night_Greeting_Is_Returned_Correctly()
    {
        var greeter = new Logic.Greeter();
        var ninePm = new DateTime(2023, 1, 1, 21, 0, 0);
        greeter.Greet(ninePm).Should().Be("Good Night");
    }
}