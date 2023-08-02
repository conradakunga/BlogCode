var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/{idNumber}", (string idNumber) => new Person { Name = "Conrad", Age = "80" });

app.Run();

public record Person
{
    public string Name { get; set; }
    public string Age { get; set; }
}