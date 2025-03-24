public sealed class TrafficLight
{
    // Public property to retrieve the status
    public Status CurrentStatus { get; private set; }

    // Internal field to help with amber tracking
    private Status _priorStatus;

    public TrafficLight()
    {
        CurrentStatus = Status.Red;
        _priorStatus = Status.Red;
    }

    public void Transition()
    {
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