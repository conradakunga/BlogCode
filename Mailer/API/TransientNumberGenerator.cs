namespace API;

public class TransientNumberGenerator
{
    public int Number { get; }

    public TransientNumberGenerator()
    {
        // Generate a number between 0 and 1000
        Number = Random.Shared.Next(0, 1_000);
    }
}