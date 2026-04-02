namespace Authenticators;

public interface IAuthenticator
{
    public void Authenticate(string username, string password);
}