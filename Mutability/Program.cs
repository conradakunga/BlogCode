using Serilog;

Console.WriteLine("");
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var jamesBond = new V1.Agent { FirstName = "James", Surname = "Bond" };

Log.Information("Agent details: {FirstName} {Surname}", jamesBond.FirstName, jamesBond.Surname);

jamesBond.FirstName = "Jane";

Log.Information("Agent details: {FirstName} {Surname}", jamesBond.FirstName, jamesBond.Surname);

var agent = new V2.Agent { FirstName = "James", Surname = "Bond" };

Log.Information("Agent details: {FirstName} {Surname}",
    agent.FirstName, agent.Surname);

//agent.FirstName = "Jane";

var vesperLynd = new V2.Agent { FirstName = "Vesper", Surname = "Lynd" };
Log.Information("Agent details: {FirstName} {Surname}", vesperLynd.FirstName, vesperLynd.Surname);
// Verpser got married
vesperLynd = new V2.Agent { FirstName = vesperLynd.FirstName, Surname = "Bond" };
Log.Information("Agent details: {FirstName} {Surname}", vesperLynd.FirstName, vesperLynd.Surname);
vesperLynd = vesperLynd with { Surname = "Bond II" };
Log.Information("Agent details: {FirstName} {Surname}", vesperLynd.FirstName, vesperLynd.Surname);