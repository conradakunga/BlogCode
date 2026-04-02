using System.DirectoryServices.Protocols;
using System.Net;

namespace Authenticators;

public sealed class LDAPAuthenticator : IAuthenticator
{
    private readonly string _domain;

    public LDAPAuthenticator(string domain)
    {
        ArgumentException.ThrowIfNullOrEmpty(domain);
        _domain = domain;
    }

    public void Authenticate(string username, string password)
    {
        ArgumentException.ThrowIfNullOrEmpty(username);
        ArgumentException.ThrowIfNullOrEmpty(password);
        try
        {
            var ldap = new LdapConnection(new LdapDirectoryIdentifier(_domain))
            {
                AuthType = AuthType.Basic
            };

            var credential = new NetworkCredential(username, password);

            ldap.Bind(credential);
        }
        catch (Exception ex)
        {
            throw new AuthenticationException("Error authenticating user!", ex);
        }
    }
}