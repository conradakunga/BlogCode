using UnitTestingLogic;

var builder = WebApplication.CreateBuilder(args);

// Register a spy manager
builder.Services.AddSingleton<ISpyManager, InMemorySpyManager>();

var app = builder.Build();

// List Spies
app.MapGet("/Spies", (ISpyManager manager) => manager.List());

// Create spy
app.MapPost("/Spy", (ISpyManager manager, CreateSpyRequest request) =>
{
    var newID = manager.Add(request);
    var result = manager.Get(newID);
    return Results.Created($"/Spy/{newID}", result);
});

// Update spy
app.MapPut("/Spy/{spyID:guid}",
    (ISpyManager manager, Guid spyID, UpdateSpyRequest request) =>
    {
        try
        {
            manager.Edit(spyID, request);
            return Results.NoContent();
        }
        catch
        {
            return Results.NotFound();
        }
    });

// Delete spy
app.MapDelete("/Spy/{spyID:guid}",
    (ISpyManager manager, Guid spyID) =>
    {
        manager.Delete(spyID);
        return Results.NoContent();
    });

// Random spies
app.MapGet("/Random/{number:int}", (ISpyManager manager, int number) => manager.GenerateRandom(number));

// Get spy
app.MapGet("/Spy/{spyID:guid}", (ISpyManager manager, Guid spyID) =>
{
    var spy = manager.Get(spyID);
    if (spy == null)
        return Results.NotFound();
    return Results.Ok(spy);
});

// Search
app.MapGet("/Search/{searchString}", (ISpyManager manager, string searchString) => manager.Search(searchString));

app.Run();

public partial class Program;