using Mailer;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Settings>(builder.Configuration.GetSection(nameof(Settings)));
var app = builder.Build();

app.MapPost("/SendGmailAlert", async (Alert alert, IOptions<Settings> settings) =>
{
    var gmailSettings = settings.Value;
    var mailer =
        new GmailAlertSender(gmailSettings.GmailPort, gmailSettings.GmailUserName, gmailSettings.GmailPassword);
    var gmailAlert = new GmailAlert(alert.Title, alert.Message);
    var alertID = await mailer.SendAlert(gmailAlert);
    return Results.Ok(alertID);
});

app.Run();