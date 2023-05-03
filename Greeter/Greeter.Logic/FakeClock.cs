namespace Greeter.Logic;

public class FakeClock : IClock
{
    public DateTime Now { get; }

    public FakeClock(DateTime dateTime)
    {
        Now = dateTime;
    }
}