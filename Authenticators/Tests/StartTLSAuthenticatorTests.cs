using Authenticators;
using AwesomeAssertions;

namespace Tests;

[Trait("Category", "LDAPS")]
public class StartTLSAuthenticatorTests
{
    [Theory]
    [InlineData("yourDomain.com", "yourUser", "yourPassword")]
    public void Valid_Username_And_ValidPassword_Succeeds(string domain, string user, string password)
    {
        var authenticator = new StartTLSAuthenticator(domain);
        var act = () => authenticator.Authenticate(user, password);
        act.Should().NotThrow();
    }

    [Theory]
    [InlineData("yourDomain.com", "yourUser", "INVALID")]
    public void Valid_Username_And_InValidPassword_Fails(string domain, string user, string password)
    {
        var authenticator = new StartTLSAuthenticator(domain);
        var act = () => authenticator.Authenticate(user, password);
        act.Should().Throw<AuthenticationException>();
    }

    [Fact]
    public void Null_Domain_Throws_Exception()
    {
        var act = () => new StartTLSAuthenticator("");
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Null_UserName_Throws_Exception()
    {
        var authenticator = new StartTLSAuthenticator("yourDomain.com");
        var act = () => authenticator.Authenticate("", "password");
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Null_Password_Throws_Exception()
    {
        var authenticator = new StartTLSAuthenticator("yourDomain.com");
        var act = () => authenticator.Authenticate("user", "");
        act.Should().Throw<ArgumentException>();
    }
}