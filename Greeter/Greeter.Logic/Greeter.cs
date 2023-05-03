namespace Greeter.Logic;
public sealed class Greeter
{
    private readonly IClock _clock;
    public Greeter(IClock clock) => _clock = clock;
    public string Greet()
    {
        return _clock.Now.Hour switch
        {
            >= 0 and < 13 => "Good Morning",
            >= 13 and < 16 => "Good Afternoon",
            >= 13 and <= 20 => "Good Evening",
            _ => "Good Night"
        };
    }
}