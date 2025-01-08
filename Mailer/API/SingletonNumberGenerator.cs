namespace API;

public class SingletonNumberGenerator
{
    public int Number { get; }

    public SingletonNumberGenerator()
    {
        // Generate a number between 0 and 1000
        Number = Random.Shared.Next(0, 1_000);
    }
}