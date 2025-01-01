using API;
using Mailer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
// Register our settings for DI
builder.Services.Configure<GmailSettings>(builder.Configuration.GetSection(nameof(GmailSettings)));
builder.Services.Configure<Office365Settings>(builder.Configuration.GetSection(nameof(Office365Settings)));
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

app.MapPost("/v2/SendGmailNormalAlert", async (Alert alert, IOptions<GmailSettings> settings) =>
{
    var gmailSettings = settings.Value;
    var mailer =
        new GmailAlertSender(gmailSettings.GmailPort, gmailSettings.GmailUserName, gmailSettings.GmailPassword);
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

app.MapPost("/v3/SendGmailNormalAlert", async (Alert alert, GmailAlertSender mailer) =>
{
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

app.MapPost("/v4/SendOffice365NormalAlert", async (Alert alert, Office365AlertSender mailer) =>
{
    var office365Alert = new Office365Alert(alert.Title, alert.Message);
    var alertID = await mailer.SendAlert(office365Alert);
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

app.Run();