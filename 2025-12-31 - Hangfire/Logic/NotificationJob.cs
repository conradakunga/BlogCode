using Microsoft.Extensions.Logging;

namespace Logic;

public sealed class NotificationJob
{
    private readonly ILogger<NotificationJob> _logger;

    public NotificationJob(ILogger<NotificationJob> logger)
    {
        _logger = logger;
    }

    public Task Execute()
    {
        _logger.LogInformation("Executing job ...");
        return Task.CompletedTask;
    }

    public async Task ExecuteLengthy()
    {
        _logger.LogInformation("Executing long running job ...");
        await Task.Delay(TimeSpan.FromMinutes(1));
        _logger.LogInformation("Completed long running job ...");
    }
}