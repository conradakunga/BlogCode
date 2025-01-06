using API;
using Mailer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace MailerTests;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

public class MailerApplicationFactory<T> : WebApplicationFactory<T>, IAsyncLifetime where T : class
{
    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    public new async Task DisposeAsync()
    {
        await base.DisposeAsync();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test"); // Use the desired environment
        builder.ConfigureAppConfiguration((context, config) =>
        {
            config.Sources.Clear();
            var env = context.HostingEnvironment;
            // Use the settings file for testing, appsettings.Test.json
            config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
            config.AddEnvironmentVariables();
        });

        // No changes to the services here, as it will use the same as the main application
        builder.ConfigureServices(services =>
        {
            // Remove the current actual implementations and replace with fakes
            services.RemoveAll<IGmailAlertSender>();
            services.RemoveAll<IOffice365AlertSender>();
            services.RemoveAll<IZohoAlertSender>();

            // Register Fake GmailAlertSender as a keyed singleton
            services.AddKeyedSingleton<IGmailAlertSender>(AlertSender.Gmail, (provider, _) =>
            {
                var settings = provider.GetRequiredService<IOptions<GmailSettings>>().Value;
                return new FakeGmailAlertSender(settings.GmailPort, settings.GmailUserName, settings.GmailPassword);
            });
            // Register Fake Office365AlertSender as a keyed singleton
            services.AddKeyedSingleton<IOffice365AlertSender>(AlertSender.Office365, (provider, _) =>
            {
                var settings = provider.GetRequiredService<IOptions<Office365Settings>>().Value;
                return new FakeOffice365AlertSender(settings.Key);
            });
            // Register Fake ZohoAlertSender as a keyed singleton
            services.AddKeyedSingleton<IZohoAlertSender>(AlertSender.Zoho, (provider, _) =>
            {
                var settings = provider.GetRequiredService<IOptions<ZohoSettings>>().Value;
                return new FakeZohoAlertSender(settings.OrganizationID, settings.SecretKey);
            });
        });
    }
}