using Bogus;
using EasyNetQ;
using Logic;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Server;

public class Publisher : BackgroundService
{
    private readonly IPubSub _pubSub;
    private readonly ILogger<Publisher> _logger;
    private readonly Faker<Spy> _faker;

    // Inject publisher and logger
    public Publisher(IPubSub pubSub, ILogger<Publisher> logger)
    {
        _pubSub = pubSub;
        _logger = logger;
        // Configure Bogus to generate spies
        _faker = new Faker<Spy>()
            .RuleFor(o => o.FirstName, f => f.Name.FirstName())
            .RuleFor(o => o.Surname, f => f.Name.LastName())
            .RuleFor(o => o.DateOfBirth, f => f.Date.Past(50));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Wait for the subscriber to start first
        await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);

        _logger.LogInformation("Publisher started");

        // Loop until application is stopped
        while (!stoppingToken.IsCancellationRequested)
        {
            // Generate spy
            var spy = _faker.Generate();

            // Publish the spy
            await _pubSub.PublishAsync(spy, stoppingToken);

            // Log what was published
            _logger.LogInformation(
                "Sent: {Surname} - {FirstName}, {DateOfBirth}", spy.Surname, spy.FirstName,
                spy.DateOfBirth);

            // Wait
            await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
        }
    }
}