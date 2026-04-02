namespace Authenticators;

public sealed class FakeLDAPAuthenticator : IAuthenticator
{
    // This simulates a user database
    private readonly IReadOnlyDictionary<string, string> _users;

    public FakeLDAPAuthenticator()
    {
        _users = new Dictionary<string, string>
        {
            ["user1"] = "password1",
            ["user2"] = "password2",
            ["user3"] = "password3"
        };
    }

    public void Authenticate(string username, string password)
    {
        if (!(_users.TryGetValue(username, out var storedPassword)
              && storedPassword == password))
            throw new AuthenticationException("LDAP authenticator failed");
    }
}