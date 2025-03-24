namespace StateMachine;

public sealed class TrafficLight
{
    private readonly TimeProvider _provider;

    // Public property to retrieve the status
    public Status CurrentStatus { get; private set; }

    // Internal field to help with amber tracking
    private Status _priorStatus;

    public TrafficLight(TimeProvider provider)
    {
        _provider = provider;
        CurrentStatus = Status.Red;
        _priorStatus = Status.Red;
    }

    public void Transition()
    {
        // Fetch the current time
        var currentTime = TimeOnly.FromTimeSpan(_provider.GetLocalNow().TimeOfDay);
        // Get midnight
        var midnight = new TimeOnly(0, 0, 0);
        // Get 6 AM
        var sixAm = new TimeOnly(6, 0, 0);
        // Check whether ot use night logic or day logic
        if (currentTime >= midnight && currentTime < sixAm)
        {
            // Transition to Amber, if not already
            if (CurrentStatus != Status.Amber)
            {
                _priorStatus = CurrentStatus;
                CurrentStatus = Status.Amber;
            }
        }
        else
        {
            // Normal schedule
            if (CurrentStatus == Status.Red)
            {
                _priorStatus = CurrentStatus;
                CurrentStatus = Status.Amber;
            }
            else if (CurrentStatus == Status.Amber && _priorStatus == Status.Red)
            {
                CurrentStatus = Status.Green;
            }
            else if (CurrentStatus == Status.Amber && _priorStatus == Status.Green)
            {
                CurrentStatus = Status.Red;
            }
            else if (CurrentStatus == Status.Green)
            {
                _priorStatus = CurrentStatus;
                CurrentStatus = Status.Amber;
            }
        }
    }
}