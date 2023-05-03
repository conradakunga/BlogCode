using FluentAssertions;

namespace Greeter.Tests;

public class GreeterTests
{
    [Fact]
    public void Morning_Greeting_Is_Returned_Correctly()
    {
        var greeter = new Logic.Greeter();
        greeter.Greet().Should().Be("Good Morning");
    }

    [Fact]
    public void Afternoons_Greeting_Is_Returned_Correctly()
    {
        var greeter = new Logic.Greeter();
        greeter.Greet().Should().Be("Good Afternoon");
    }

    [Fact]
    public void Evening_Greeting_Is_Returned_Correctly()
    {
        var greeter = new Logic.Greeter();
        greeter.Greet().Should().Be("Good Evening");
    }
    [Fact]
    public void Night_Greeting_Is_Returned_Correctly()
    {
        var greeter = new Logic.Greeter();
        greeter.Greet().Should().Be("Good Night");
    }
}