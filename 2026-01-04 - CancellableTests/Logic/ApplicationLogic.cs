namespace Logic;

public class ApplicationLogic
{
    public async Task<string> LongRunningOperation(CancellationToken ct)
    {
        await Task.Delay(TimeSpan.FromSeconds(30), ct);
        return "Success";
    }
}