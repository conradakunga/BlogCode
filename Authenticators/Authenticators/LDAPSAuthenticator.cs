using System.DirectoryServices.Protocols;
using System.Net;

namespace Authenticators;

public sealed class LDAPSAuthenticator : IAuthenticator
{
    private const int LDAPSPort = 636;
    private readonly string _domain;

    public LDAPSAuthenticator(string domain)
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
            var identifier = new LdapDirectoryIdentifier(_domain, LDAPSPort, fullyQualifiedDnsHostName: true,
                connectionless: false);

            var connection = new LdapConnection(identifier)
            {
                Credential = new NetworkCredential(username, password),
                AuthType = AuthType.Negotiate
            };

            // Enforce SSL (LDAPS)
            connection.SessionOptions.SecureSocketLayer = true;

            // Authenticate
            connection.Bind();
        }
        catch (LdapException ex)
        {
            throw new AuthenticationException($"Ldap Exception: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            throw new AuthenticationException($"General Authentication Exception: {ex.Message}", ex);
        }
    }
}