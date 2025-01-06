using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using FluentAssertions;
using Mailer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Time.Testing;

namespace MailerTests;

public class TimedAlertSenderTests : IClassFixture<MailerApplicationFactory<Program>>
{
    private readonly MailerApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public TimedAlertSenderTests(MailerApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Alert_Is_Sent_Successfully()
    {
        var request = new GeneralAlert("Title", "Message");
        var response = await _client.PostAsJsonAsync("/v13/SendEmergencyAlert", request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Morning_Alert_Is_Sent_Successfully()
    {
        // Create a fake time provider
        var fake = new FakeTimeProvider();
        // Set the time to 11 AM. The date doesn't matter
        fake.SetUtcNow(new DateTimeOffset(new DateTime(2025, 1, 1, 11, 0, 0)));

        // Use the currently configured DI configuration as a starting point
        var client = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                // Remove the system time provider
                var descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(TimeProvider));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Add our fake time provider to the DI container
                services.AddSingleton<TimeProvider>(fake);
            });
        }).CreateClient();

        var request = new GeneralAlert("Title", "Message");
        var response = await client.PostAsJsonAsync("/v13/SendEmergencyAlert", request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var responseString = await response.Content.ReadAsStringAsync();
        // One of the returned values should be the Guid FFFF for Gmail
        responseString.Should().Contain("ffffffff-ffff-ffff-ffff-ffffffffffff");
        // One of the returned values should be the Guid DDDD for Zoho 
        responseString.Should().Contain("dddddddd-dddd-dddd-dddd-dddddddddddd");
        // Check that only two values were returned
        JsonSerializer.Deserialize<Guid[]>(responseString)!.Length.Should().Be(2);
    }

    [Fact]
    public async Task Afternoon_Alert_Is_Sent_Successfully()
    {
        // Create a fake time provider
        var fake = new FakeTimeProvider();
        // Set the time to 12 AM. The date doesn't matter
        fake.SetUtcNow(new DateTimeOffset(new DateTime(2025, 1, 1, 12, 0, 0)));

        var client = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                // Remove the system time provider
                var descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(TimeProvider));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Add our fake time provider to the DI container
                services.AddSingleton<TimeProvider>(fake);
            });
        }).CreateClient();

        var request = new GeneralAlert("Title", "Message");
        var response = await client.PostAsJsonAsync("/v13/SendEmergencyAlert", request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var responseString = await response.Content.ReadAsStringAsync();
        // One of the returned values should be the Guid EEEE for office 
        responseString.Should().Contain("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee");
        // One of the returned values should be the Guid DDDD for Zoho 
        responseString.Should().Contain("dddddddd-dddd-dddd-dddd-dddddddddddd");
        // Check that only two values were returned
        JsonSerializer.Deserialize<Guid[]>(responseString)!.Length.Should().Be(2);
    }
}