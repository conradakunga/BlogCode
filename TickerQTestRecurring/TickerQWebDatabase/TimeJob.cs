using TickerQ.Utilities.Base;

public sealed class TimeJob
{
    private readonly ILogger<Program> _logger;

    public TimeJob(ILogger<Program> logger)
    {
        _logger = logger;
    }

    // Set function to run daily at 9:45 PM
    [TickerFunction("UTCTime", cronExpression: "0 45 21 * * *")]
    public void PrintUTCTime(TickerFunctionContext ctx, CancellationToken ct)
    {
        _logger.LogInformation("The time now is {CurrentTime:d MMM yyyy HH:mm:ss zzz} (JobID {JobID})",
            DateTime.UtcNow, ctx.Id);
    }
}