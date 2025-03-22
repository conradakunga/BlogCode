using Carter;
using Microsoft.IO;
using XMLSerialization;

var builder = WebApplication.CreateBuilder(args);

// Add carter support to the services
builder.Services.AddCarter(configurator: c =>
{
    // Register a XML response negotiator
    c.WithResponseNegotiator<XmlResponseNegotiator>();
});

builder.Services.AddSingleton<RecyclableMemoryStreamManager>();

var app = builder.Build();

// Scan and register all Carter modules
app.MapCarter();

app.Run();