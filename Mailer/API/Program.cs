using API;
using Mailer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
// Register our settings for DI
builder.Services.Configure<GmailSettings>(builder.Configuration.GetSection(nameof(GmailSettings)));
builder.Services.Configure<Office365Settings>(builder.Configuration.GetSection(nameof(Office365Settings)));
builder.Services.Configure<ZohoSettings>(builder.Configuration.GetSection(nameof(ZohoSettings)));
builder.Services.Configure<GeneralSettings>(builder.Configuration.GetSection(nameof(GeneralSettings)));

// Register our GmailSender, passing our settings
builder.Services.AddSingleton<GmailAlertSender>(provider =>
{
    // Fetch the settings from the DI Container
    var settings = provider.GetService<IOptions<GmailSettings>>()!.Value;
    return new GmailAlertSender(settings.GmailPort, settings.GmailUserName,
        settings.GmailPassword);
});
// Register our Office365 sender, passing our settings
builder.Services.AddSingleton<Office365AlertSender>(provider =>
{
    // Fetch the settings from the DI Container
    var settings = provider.GetService<IOptions<Office365Settings>>()!.Value;
    return new Office365AlertSender(settings.Key);
});

// Register our Zoho sender, passing our settings
builder.Services.AddSingleton<ZohoAlertSender>(provider =>
{
    // Fetch the settings from the DI Container
    var settings = provider.GetService<IOptions<ZohoSettings>>()!.Value;
    return new ZohoAlertSender(settings.OrganizationID, settings.SecretKey);
});

// // Create an instance of the class to hold the settings
// var generalSettings = new GeneralSettings();
// // Bind the new class to the settings defined in the appsettings.json
// builder.Configuration.GetSection(nameof(GeneralSettings)).Bind(generalSettings);
// // Conditionally configure the DI depending on specified sender
// switch (generalSettings.AlertSender)
// {
//     case AlertSender.Gmail:
//         // Register our generic Gmail sender, passing our settings
//         builder.Services.AddSingleton<IAlertSender>(provider =>
//         {
//             // Fetch the settings from the DI Container
//             var settings = provider.GetService<IOptions<GmailSettings>>()!.Value;
//             return new GmailAlertSender(settings.GmailPort, settings.GmailUserName,
//                 settings.GmailPassword);
//         });
//         break;
//     case AlertSender.Office365:
//         // Register our generic Office365 sender, passing our settings
//         builder.Services.AddSingleton<IAlertSender>(provider =>
//         {
//             // Fetch the settings from the DI Container
//             var settings = provider.GetService<IOptions<Office365Settings>>()!.Value;
//             return new Office365AlertSender(settings.Key);
//         });
//         break;
//     case AlertSender.Zoho:
//         // Register our generic Zoho sender, passing our settings
//         builder.Services.AddSingleton<IAlertSender>(provider =>
//         {
//             // Fetch the settings from the DI Container
//             var settings = provider.GetService<IOptions<ZohoSettings>>()!.Value;
//             return new ZohoAlertSender(settings.OrganizationID, settings.SecretKey);
//         });
//         break;
// }

// Add support for OptionsMonitor
builder.Services.AddSingleton<IOptionsMonitor<GeneralSettings>, OptionsMonitor<GeneralSettings>>();

// Add support for an AlertSender factory
builder.Services.AddSingleton<IAlertSenderFactory, AlertSenderFactory>();

// Keyed services registration
// Register GmailAlertSender as a keyed singleton
builder.Services.AddKeyedSingleton<IAlertSender, GmailAlertSender>(AlertSender.Gmail, (provider, _) =>
{
    var settings = provider.GetRequiredService<IOptions<GmailSettings>>().Value;
    return new GmailAlertSender(settings.GmailPort, settings.GmailUserName, settings.GmailPassword);
});

// Register Office365AlertSender as a keyed singleton
builder.Services.AddKeyedSingleton<IAlertSender, Office365AlertSender>(AlertSender.Office365, (provider, _) =>
{
    var settings = provider.GetRequiredService<IOptions<Office365Settings>>().Value;
    return new Office365AlertSender(settings.Key);
});

// Register ZohoAlertSender as a keyed singleton
builder.Services.AddKeyedSingleton<IAlertSender, ZohoAlertSender>(AlertSender.Zoho, (provider, _) =>
{
    var settings = provider.GetRequiredService<IOptions<ZohoSettings>>().Value;
    return new ZohoAlertSender(settings.OrganizationID, settings.SecretKey);
});

var app = builder.Build();

app.MapPost("/v1/SendGmailEmergencyAlert", async (Alert alert) =>
{
    var mailer =
        new GmailAlertSender(400, "username", "password");
    var gmailAlert = new GmailAlert(alert.Title, alert.Message);
    var alertID = await mailer.SendAlert(gmailAlert);
    return Results.Ok(alertID);
});

app.MapPost("/v2/SendGmailEmergencyAlert", async (Alert alert, IOptions<GmailSettings> settings) =>
{
    var gmailSettings = settings.Value;
    var mailer =
        new GmailAlertSender(gmailSettings.GmailPort, gmailSettings.GmailUserName, gmailSettings.GmailPassword);
    var gmailAlert = new GmailAlert(alert.Title, alert.Message);
    var alertID = await mailer.SendAlert(gmailAlert);
    return Results.Ok(alertID);
});

app.MapPost("/v3/SendGmailEmergencyAlert", async ([FromBody] Alert alert, [FromServices] GmailAlertSender mailer,
    [FromServices] ILogger<Program> logger) =>
{
    logger.LogInformation("Active Configuration: {Configuration}", mailer.Configuration);
    var gmailAlert = new GmailAlert(alert.Title, alert.Message);
    var alertID = await mailer.SendAlert(gmailAlert);
    return Results.Ok(alertID);
});

app.MapPost("/v4/SendOffice365EmergencyAlert", async ([FromBody] Alert alert,
    [FromServices] Office365AlertSender mailer, [FromServices] ILogger<Program> logger) =>
{
    logger.LogInformation("Active Configuration: {Configuration}", mailer.Configuration);
    var office365Alert = new Office365Alert(alert.Title, alert.Message);
    var alertID = await mailer.SendAlert(office365Alert);
    return Results.Ok(alertID);
});

app.MapPost("/v5/SendEmergencyAlert", async ([FromBody] Alert alert,
    [FromServices] IAlertSender mailer, [FromServices] ILogger<Program> logger) =>
{
    logger.LogInformation("Active Configuration: {Configuration}", mailer.Configuration);
    // Map the client provide alert to the server side alert
    var genericAlert = new GeneralAlert(alert.Title, alert.Message);
    var alertID = await mailer.SendAlert(genericAlert);
    return Results.Ok(alertID);
});


app.MapPost("/v6/SendEmergencyAlert", async ([FromBody] Alert alert,
    IOptionsMonitor<GeneralSettings> settingsMonitor, IOptions<GmailSettings> gmailOptions,
    IOptions<Office365Settings> office365Options, IOptions<ZohoSettings> zohoOptions,
    [FromServices] ILogger<Program> logger) =>
{
    var settings = settingsMonitor.CurrentValue;
    logger.LogInformation("Current Sender: {Configuration}", settings.AlertSender);
    IAlertSender mailer;
    switch (settings.AlertSender)
    {
        case AlertSender.Gmail:
            var gmailSettings = gmailOptions.Value;
            mailer = new GmailAlertSender(gmailSettings.GmailPort, gmailSettings.GmailUserName,
                gmailSettings.GmailPassword);
            break;
        case AlertSender.Office365:
            var office365Settings = office365Options.Value;
            mailer = new Office365AlertSender(office365Settings.Key);
            break;
        case AlertSender.Zoho:
            var zohoSettings = zohoOptions.Value;
            mailer = new ZohoAlertSender(zohoSettings.OrganizationID, zohoSettings.SecretKey);
            break;
        default:
            throw new ArgumentException("Configured alert sender not found");
    }

    var genericAlert = new GeneralAlert(alert.Title, alert.Message);
    await mailer.SendAlert(genericAlert);

    return Results.Ok();
});

app.MapPost("/v7/SendEmergencyAlert", async ([FromBody] Alert alert,
    IOptionsMonitor<GeneralSettings> settingsMonitor, [FromServices] IAlertSenderFactory factory,
    [FromServices] ILogger<Program> logger) =>
{
    var settings = settingsMonitor.CurrentValue;
    logger.LogInformation("Current Sender: {Configuration}", settings.AlertSender);
    // Create a mailer using the injected factory
    var mailer = factory.CreateAlertSender(settings.AlertSender);
    var genericAlert = new GeneralAlert(alert.Title, alert.Message);
    await mailer.SendAlert(genericAlert);

    return Results.Ok();
});

app.MapPost("/v8/SendEmergencyAlert", async ([FromBody] Alert alert,
    IOptionsMonitor<GeneralSettings> settingsMonitor, IServiceProvider provider,
    [FromServices] ILogger<Program> logger) =>
{
    var settings = settingsMonitor.CurrentValue;
    logger.LogInformation("Current Sender: {Configuration}", settings.AlertSender);
    // Retrieve sender from DI 
    IAlertSender mailer = settings.AlertSender switch
    {
        AlertSender.Gmail => provider.GetRequiredService<GmailAlertSender>(),
        AlertSender.Office365 => provider.GetRequiredService<Office365AlertSender>(),
        AlertSender.Zoho => provider.GetRequiredService<ZohoAlertSender>(),
        _ => throw new ArgumentException("Unsupported alert sender selected")
    };
    var genericAlert = new GeneralAlert(alert.Title, alert.Message);
    await mailer.SendAlert(genericAlert);

    return Results.Ok();
});

app.MapPost("/v9/SendEmergencyAlert", async ([FromBody] Alert alert,
    IOptionsMonitor<GeneralSettings> settingsMonitor, IServiceProvider provider,
    [FromServices] ILogger<Program> logger) =>
{
    var settings = settingsMonitor.CurrentValue;
    logger.LogInformation("Current Sender: {Configuration}", settings.AlertSender);
    // Retrieve sender from DI 
    var mailer = provider.GetRequiredKeyedService<IAlertSender>(settings.AlertSender);
    var genericAlert = new GeneralAlert(alert.Title, alert.Message);
    await mailer.SendAlert(genericAlert);

    return Results.Ok();
});

app.Run();