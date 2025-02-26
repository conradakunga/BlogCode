using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);

// Setup DI to inject a Sqlite connection
builder.Services.AddSingleton<SqliteConnection>(_ => new SqliteConnection(Initializer.ConnectionString));

var app = builder.Build();
// Ensure our database is created and seeded
Initializer.EnsureDatabaseExists();

app.MapPost("/Login", (SqliteConnection cn, ILogger<Program> logger, LoginRequest request) =>
{
    var param = new DynamicParameters();
    // Create the Username parameter, specifying all the details
    param.Add("Username", request.Username, DbType.String, ParameterDirection.Input, 100);
    // Crete the password parameter
    param.Add("Password", request.Password);
    // Set the command query text
    var query = "SELECT 1 FROM USERS WHERE Username=@Username AND Password=@Password";
    // Execute the query
    var status = cn.QuerySingleOrDefault<int>(query, param);
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