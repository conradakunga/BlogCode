using Authenticators;
using AwesomeAssertions;

namespace Tests;

[Trait("Category", "Fake LDAP")]
public class FakeLDAPAuthenticatorTests
{
    private readonly FakeLDAPAuthenticator _authenticator;

    public FakeLDAPAuthenticatorTests()
    {
        _authenticator = new FakeLDAPAuthenticator();
    }

    [Fact]
    public void Valid_Username_And_ValidPassword_Succeeds()
    {
        var act = () => _authenticator.Authenticate("user1", "password1");
        act.Should().NotThrow();
    }

    [Fact]
    public void Valid_Username_And_InValidPassword_Fails()
    {
        var act = () => _authenticator.Authenticate("user1", "FAIL");
        act.Should().Throw<AuthenticationException>();
    }

    [Fact]
    public void Valid_Username_And_ValidPassword_For_Different_User_Fails()
    {
        var act = () => _authenticator.Authenticate("user1", "password2");
        act.Should().Throw<AuthenticationException>();
    }

    [Fact]
    public void Invalid_Username_And_InValidPassword_For_Different_User_Fails()
    {
        var act = () => _authenticator.Authenticate("INVALID", "INVALID");
        act.Should().Throw<AuthenticationException>();
    }
}