using Carter;

var builder = WebApplication.CreateBuilder(args);

// Add carter support to the services
builder.Services.AddCarter(configurator: c =>
{
    // Register a XML response negotiator
    c.WithResponseNegotiator<XMLResponseNegotiator>();
    c.WithResponseNegotiator<CSVResponseNegotiator>();
});

var app = builder.Build();

// Scan and register all Carter modules
app.MapCarter();

app.Run();