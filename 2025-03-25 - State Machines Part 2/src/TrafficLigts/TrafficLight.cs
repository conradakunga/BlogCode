using Stateless;
using Stateless.Graph;

namespace StateMachineSample;

public sealed class TrafficLight
{
    private readonly TimeProvider _provider;
    private readonly StateMachine<Status, Trigger> _stateMachine;
    public Status CurrentStatus => _stateMachine.State;
    private readonly DateOnly[] _holidays;

    public TrafficLight(TimeProvider provider, Status state = Status.Red)
    {
        // Declare a bunch of holidays
        var christmasDay = new DateOnly(2025, 12, 25);
        var boxingDay = new DateOnly(2025, 12, 26);
        var newYearsDay = new DateOnly(2025, 1, 1);

        // Set the array
        _holidays = [christmasDay, boxingDay, newYearsDay];

        // Assign the provider
        _provider = provider;

        // Create the state machine, and set the initial state as red
        _stateMachine = new StateMachine<Status, Trigger>(state);

        //
        // Configure state machine
        //

        // If red, can only transition to amber from red
        _stateMachine.Configure(Status.Red)
            .Permit(Trigger.NormalTimerTick, Status.AmberFromRed)
            .Permit(Trigger.NightTimerTick, Status.AmberFromRed)
            .Permit(Trigger.PublicHolidayTimerTick, Status.AmberFromRed);

        _stateMachine.Configure(Status.AmberFromRed)
            .Permit(Trigger.NormalTimerTick, Status.Green)
            // Since state is already AmberFromRed, ignore transitions
            .Ignore(Trigger.NightTimerTick)
            .Ignore(Trigger.PublicHolidayTimerTick);

        _stateMachine.Configure(Status.Green)
            .Permit(Trigger.NormalTimerTick, Status.AmberFromGreen)
            .Permit(Trigger.NightTimerTick, Status.AmberFromRed)
            .Permit(Trigger.PublicHolidayTimerTick, Status.AmberFromRed);

        _stateMachine.Configure(Status.AmberFromGreen)
            .Permit(Trigger.NormalTimerTick, Status.Red)
            .Permit(Trigger.NightTimerTick, Status.AmberFromRed)
            .Permit(Trigger.PublicHolidayTimerTick, Status.AmberFromRed);
    }

    // Logic to transition the state
    public void Transition()
    {
        //Fetch the current ate
        var currentDate = DateOnly.FromDateTime(_provider.GetLocalNow().Date);
        // Check if holidays contain the current date
        if (_holidays.Any(x => x.Month == currentDate.Month && x.Day == currentDate.Day))
        {
            _stateMachine.Fire(Trigger.PublicHolidayTimerTick);
        }
        else
        {
            // Fetch the current time
            var currentTime = TimeOnly.FromTimeSpan(_provider.GetLocalNow().TimeOfDay);
            // Get midnight
            var midnight = new TimeOnly(0, 0, 0);
            // Get 6 AM
            var sixAm = new TimeOnly(6, 0, 0);
            // Check whether ot use night logic or day logic
            if (currentTime >= midnight && currentTime < sixAm)
                _stateMachine.Fire(Trigger.NightTimerTick);
            else
                _stateMachine.Fire(Trigger.NormalTimerTick);
        }
    }
}