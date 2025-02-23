using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);

// Setup DI to inject a Sqlite connection
builder.Services.AddSingleton<SqliteConnection>(_ => new SqliteConnection(Initializer.ConnectionString));

var app = builder.Build();
// Ensure our database is created and seeded
Initializer.EnsureDatabaseExists();

app.MapPost("/Login", (SqliteConnection cn, ILogger<Program> logger, LoginRequest request) =>
{
    // Open a connection to the database from the injected connection
    cn.Open();
    // Create a command object from the connection
    var cmd = cn.CreateCommand();
    // Build the query that checks valid logins
    var query = $"SELECT 1 FROM USERS WHERE Username='{request.Username}' AND Password='{request.Password}'";
    // Log the query, so we can visualize it
    logger.LogWarning("Query: {Query}", query);
    // Set the command query text
    cmd.CommandText = query;
    // Execute the query
    var status = Convert.ToInt32(cmd.ExecuteScalar());
    // Check the returned number
    if (status == 1)
    {
        // We are now logged in
        logger.LogInformation("User logged in successfully");
        return Results.Ok();
    }

    logger.LogError("Login Failed");
    // Return a 401
    return Results.Unauthorized();
});

app.Run();