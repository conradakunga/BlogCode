namespace GreeterLogic;

public sealed class Greeter
{
    private readonly TimeProvider _timeProvider;

    public Greeter(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public string Greet()
    {
        return _timeProvider.GetLocalNow().Hour switch
        {
            >= 0 and < 13 => "Good Morning",
            >= 13 and <= 16 => "Good Afternoon",
            > 16 and <= 20 => "Good Evening",
            _ => "Good Night"
        };
    }
}