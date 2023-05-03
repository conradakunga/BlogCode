namespace Greeter.Logic;
public sealed class Greeter
{
    public string Greet(DateTime dateTime)
    {
        return dateTime.Hour switch
        {
            >= 0 and < 13 => "Good Morning",
            >= 13 and < 16 => "Good Afternoon",
            >= 13 and <= 20 => "Good Evening",
            _ => "Good Night"
        };
    }
}