namespace API;

public class ScopedNumberGenerator
{
    public int Number { get; }

    public ScopedNumberGenerator()
    {
        // Generate a number between 0 and 1000
        Number = Random.Shared.Next(0, 1_000);
    }
}