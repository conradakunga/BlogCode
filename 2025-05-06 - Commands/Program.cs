using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "data source=.;database=Spies;uid=sa;pwd=YourStrongPassword123;Encrypt=false";

var builder = WebApplication.CreateBuilder(args);

// Setup DI to inject a Sql Server connection
builder.Services.AddSingleton<SqlConnection>(_ => new SqlConnection(connectionString));

var app = builder.Build();

app.MapGet("/SpiesByText", async (SqlConnection cn) =>
{
    var result = await cn.QueryAsync<Spy>("SELECT * FROM Spies");
    return result;
});

app.MapGet("/SpiesByTextRaw", async (SqlConnection cn, CancellationToken token) =>
{
    var spies = new List<Spy>();
    // Open the connection
    await cn.OpenAsync(token);
    // Create  a command
    await using var cmd = cn.CreateCommand();
    // Set the command text
    cmd.CommandText = "SELECT * FROM Spies";
    // Set the command type
    cmd.CommandType = CommandType.Text;
    // Execute the command and get back a reader, specifying the connection to be closed
    // after the reader is closed
    var reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection, token);
    // Scroll forwards through the results
    while (await reader.ReadAsync(token))
    {
        // Add to the collection
        spies.Add(new Spy
        {
            // Read the value from the column specified
            SpyID = reader.GetInt32(reader.GetOrdinal("SpyID")),
            Name = reader.GetString(reader.GetOrdinal("Name")),
            DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
        });
    }

    // Close the reader
    await reader.CloseAsync();

    return spies;
});

app.MapGet("/SpiesByProcedure", async (SqlConnection cn) =>
{
    var result = await cn.QueryAsync<Spy>("[Spies.GetAll]");
    return result;
});

app.Run();