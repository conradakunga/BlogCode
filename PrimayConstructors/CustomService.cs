namespace PrimayConstructors;

public class CustomService(TimeProvider provider)
{
    public DateTime GetTime => provider.GetUtcNow().DateTime;
}