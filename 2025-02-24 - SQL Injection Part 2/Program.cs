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
    // Set the command query text
    cmd.CommandText = "SELECT 1 FROM USERS WHERE Username=@Username AND Password=@Password";
    //
    // Add the parameters
    //

    // Username
    var paramUsername = cmd.CreateParameter();
    paramUsername.SqliteType = SqliteType.Text;
    paramUsername.ParameterName = "@Username";
    paramUsername.Size = 100;
    paramUsername.Value = request.Username;
    cmd.Parameters.Add(paramUsername);
    // Password
    cmd.Parameters.AddWithValue("@Password", request.Password).Size = 100;


    // Loop through the parameters and print the name and value
    foreach (SqliteParameter param in cmd.Parameters)
    {
        logger.LogWarning("Parameter Name: {Name}; Value: {Value}", param.ParameterName, param.Value);
    }

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