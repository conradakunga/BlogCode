using System.DirectoryServices.Protocols;
using System.Net;

namespace Authenticators;

public sealed class StartTLSAuthenticator : IAuthenticator
{
    private const int StartTLSPort = 389;
    private readonly string _domain;

    public StartTLSAuthenticator(string domain)
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
            var identifier = new LdapDirectoryIdentifier(_domain, StartTLSPort);

            var connection = new LdapConnection(identifier)
            {
                Credential = new NetworkCredential(username, password),
                AuthType = AuthType.Negotiate
            };

            // Require TLS upgrade
            connection.SessionOptions.ProtocolVersion = 3;

            // Upgrade to TLS (StartTLS)
            connection.SessionOptions.StartTransportLayerSecurity(null);

            // Now the connection is encrypted
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