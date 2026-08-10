using Microsoft.Extensions.Time.Testing;
using PrimayConstructors;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<TimeProvider>(new FakeTimeProvider(new DateTime(2000, 1, 1)));
builder.Services.AddSingleton<CustomService>();
var app = builder.Build();

app.MapGet("/", (CustomService service) => $"Hello World at {service.GetTime:d MMM yyyy HH:mm}");

app.Run();