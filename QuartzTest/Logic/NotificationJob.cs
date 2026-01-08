using Quartz;
using Serilog;

public sealed class NotificationJob : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        Log.Information("Executing job ...");
        return Task.CompletedTask;
    }
}