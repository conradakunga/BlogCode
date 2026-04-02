namespace Authenticators;

public class AuthenticationException : Exception
{
    public AuthenticationException(string message) : base(message)
    {
    }

    public AuthenticationException(string message, Exception exception) : base(message, exception)
    {
    }
}