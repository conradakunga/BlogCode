using Authenticators;
using AwesomeAssertions;
using Moq;

namespace Tests;

[Trait("Category", "Behaviour")]
public class AuthenticatorBehaviourTests
{
    private readonly IAuthenticator _authenticator;

    public AuthenticatorBehaviourTests()
    {
        // Set up our mock
        var sut = new Mock<IAuthenticator>();
        // Configure success path for a valid password
        sut.Setup(x => x.Authenticate("username", "ValidPassword"));
        // Configure success path for an invalid password
        sut.Setup(x =>
                x.Authenticate(It.IsNotIn("username"), It.IsNotIn("ValidPassword")))
            .Throws<AuthenticationException>();

        // Get an instance from the mock
        _authenticator = sut.Object;
    }

    [Fact]
    public void Authenticator_Behavior_Valid_Password_Authenticates()
    {
        var act = () => _authenticator.Authenticate("username", "ValidPassword");
        act.Should().NotThrow();
    }

    [Fact]
    public void Authenticator_Behavior_Invalid_Password_Authenticates()
    {
        var act = () => _authenticator.Authenticate("username", "InvalidPassword");
        act.Should().Throw<AuthenticationException>();
    }
}