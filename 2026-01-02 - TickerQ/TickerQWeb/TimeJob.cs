using TickerQ.Utilities.Base;

public sealed class TimeJob
{
    private readonly ILogger<Program> _logger;

    public TimeJob(ILogger<Program> logger)
    {
        _logger = logger;
    }

    [TickerFunction("UTCTime", cronExpression: "*/20 * * * * *")]
    public void PrintUTCTime(TickerFunctionContext ctx, CancellationToken ct)
    {
        _logger.LogInformation("The time now is {CurrentTime:d MMM yyyy HH:mm:ss zzz} (JobID {JobID})",
            DateTime.UtcNow, ctx.Id);
    }
}