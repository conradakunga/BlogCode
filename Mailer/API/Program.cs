using API;
using Mailer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Settings>(builder.Configuration.GetSection(nameof(Settings)));

// Declare our class and bind it to the settings
var appSettings = new Settings();
builder.Configuration.GetSection(nameof(Settings)).Bind(appSettings);
// Register our GmailSender, passing our settings
builder.Services.AddSingleton<GmailAlertSender>(provider =>
{
    // Fetch the settings from the DI Container
    var settings = provider.GetService<IOptions<Settings>>()!.Value;
    return new GmailAlertSender(settings.GmailPort, settings.GmailUserName,
        settings.GmailPassword);
});
var app = builder.Build();

app.MapPost("/v1/SendGmailNormalAlert", async (Alert alert) =>
{
    var mailer =
        new GmailAlertSender(400, "username", "password");
    var gmailAlert = new GmailAlert(alert.Title, alert.Message);
    var alertID = await mailer.SendAlert(gmailAlert);
    return Results.Ok(alertID);
});

app.MapPost("/v1/SendGmailEmergencyAlert", async (Alert alert) =>
{
    var mailer =
        new GmailAlertSender(400, "username", "password");
    var gmailAlert = new GmailAlert(alert.Title, alert.Message);
    var alertID = await mailer.SendAlert(gmailAlert);
    return Results.Ok(alertID);
});

app.MapPost("/v2/SendGmailNormalAlert", async (Alert alert, IOptions<Settings> settings) =>
{
    var gmailSettings = settings.Value;
    var mailer =
        new GmailAlertSender(gmailSettings.GmailPort, gmailSettings.GmailUserName, gmailSettings.GmailPassword);
    var gmailAlert = new GmailAlert(alert.Title, alert.Message);
    var alertID = await mailer.SendAlert(gmailAlert);
    return Results.Ok(alertID);
});

app.MapPost("/v2/SendGmailEmergencyAlert", async (Alert alert, IOptions<Settings> settings) =>
{
    var gmailSettings = settings.Value;
    var mailer =
        new GmailAlertSender(gmailSettings.GmailPort, gmailSettings.GmailUserName, gmailSettings.GmailPassword);
    var gmailAlert = new GmailAlert(alert.Title, alert.Message);
    var alertID = await mailer.SendAlert(gmailAlert);
    return Results.Ok(alertID);
});

app.MapPost("/v3/SendGmailNormalAlert", async (Alert alert, GmailAlertSender mailer) =>
{
    var gmailAlert = new GmailAlert(alert.Title, alert.Message);
    var alertID = await mailer.SendAlert(gmailAlert);
    return Results.Ok(alertID);
});

app.MapPost("/v3/SendGmailEmergencyAlert", async ([FromBody] Alert alert, [FromServices] GmailAlertSender mailer) =>
{
    var gmailAlert = new GmailAlert(alert.Title, alert.Message);
    var alertID = await mailer.SendAlert(gmailAlert);
    return Results.Ok(alertID);
});

app.Run();