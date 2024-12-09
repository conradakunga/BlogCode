using SpiesAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var spies = new List<Spy>();

// List all spies
app.MapGet("/Spies", () =>
{
    // Fetch all spies from the database
    return Results.Ok(spies);
});

// Get a spy by ID
app.MapGet("/Spies/{id:guid}", (Guid id) =>
{
    //Fetch requested spy from database
    var spy = spies.SingleOrDefault(x => x.ID == id);
    if (spy is null)
        return Results.NotFound();
    return Results.Ok(spy);
});

// Create a spy
app.MapPost("/Spies", (CreateSpyRequest request) =>
{
    //Create a spy
    var spy = new Spy(Guid.NewGuid(), request.Name, request.DateOfBirth);
    // Add to database
    spies.Add(spy);
    return Results.Created($"/Spies/{spy.ID}", spy);
});

// Update a spy's details
app.MapPut("/Spies", (UpdateSpyRequest request) =>
{
    //Fetch spy from database
    var spy = spies.SingleOrDefault(x => x.ID == request.ID);
    if (spy is null)
        return Results.NotFound();
    spies.Remove(spy);
    var updatedSpy = spy with { Name = request.Name, DateOfBirth = request.DateOfBirth };
    spies.Add(updatedSpy);
    return Results.NoContent();
});

// Delete a spy
app.MapDelete("/Spies/{id:guid}", (Guid id) =>
{
    var spy = spies.SingleOrDefault(x => x.ID == id);
    if (spy is null)
        return Results.NotFound();
    spies.Remove(spy);
    return Results.NoContent();
});

// HEAD request to check for existence
app.MapMethods("/Spies/{id:guid}", [HttpMethod.Head.Method], (Guid id) =>
{
    // Query the database for existence of the spy by ID
    if (spies.Any(x => x.ID == id))
        return Results.Ok();
    return Results.NotFound();
});

app.Run();