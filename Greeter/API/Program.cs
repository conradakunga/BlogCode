using Greeter.Logic;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IClock, SystemClock>();
builder.Services.AddSingleton<Greeter.Logic.Greeter>();
var app = builder.Build();

app.MapGet("/", (Greeter.Logic.Greeter greeter) => $"Hello World! {greeter.Greet()}");

app.Run();