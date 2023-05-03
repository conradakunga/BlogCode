namespace Greeter.Logic;

public class SystemClock : IClock
{
    public DateTime Now => DateTime.Now;
}