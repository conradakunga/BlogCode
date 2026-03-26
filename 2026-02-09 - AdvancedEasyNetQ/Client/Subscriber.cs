using EasyNetQ;
using Logic;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Client;

public class Subscriber : BackgroundService
{
    private readonly IPubSub _pubSub;
    private readonly ILogger<Subscriber> _logger;

    // Inject subscriber and logger
    public Subscriber(IPubSub pubSub, ILogger<Subscriber> logger)
    {
        _pubSub = pubSub;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Configure subscription event
        await _pubSub.SubscribeAsync<Spy>("ConsoleSubscriber", message =>
        {
            // Log result
            _logger.LogInformation(
                "Received: {Surname} - {FirstName}, {DateOfBirth}", message.Surname, message.FirstName,
                message.DateOfBirth);
        }, cancellationToken: stoppingToken);
    }
}