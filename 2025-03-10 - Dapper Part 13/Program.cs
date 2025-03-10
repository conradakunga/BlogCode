using Bogus;
using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "data source=10.211.55.2;database=Spies;uid=sa;pwd=YourStrongPassword123;Encrypt=false";

var builder = WebApplication.CreateBuilder(args);

// Setup DI to inject a Sql Server connection
builder.Services.AddSingleton<SqlConnection>(_ => new SqlConnection(connectionString));

var app = builder.Build();

app.MapPost("/Update/v1", async (SqlConnection cn) =>
{
    // setup our update queries
    const string firstUpdate = "UPDATE Spies SET Name = 'James Perceval Bond' WHERE SpyID = 1";
    const string secondUpdate = "UPDATE Spies SET Name = 'Eve Janet MoneyPenny' WHERE SpyID = 2";
    const string thirdUpdate = "UPDATE Spies SET Name = 'Vesper Leonora Lynd' WHERE SpyID = 3";

    // Execute our queries
    await cn.ExecuteAsync(firstUpdate);
    await cn.ExecuteAsync(secondUpdate);
    await cn.ExecuteAsync(thirdUpdate);

    // Return ok
    return Results.Ok();
});

app.MapPost("/Update/v2", async (SqlConnection cn, ILogger<Program> logger) =>
{
    // Open the connection
    await cn.OpenAsync();
    // Obtain a transaction from the connection
    await using (var trans = await cn.BeginTransactionAsync())
    {
        try
        {
            // setup our update queries
            const string firstUpdate = "UPDATE Spies SET Name = 'James Michael Bond' WHERE SpyID = 1";
            const string secondUpdate = "UPDATE Spies SET Name = 'Eve Jean MoneyPenny' WHERE SpyID = 2";
            const string thirdUpdate = "UPDATE Spies SET Name = 'Vesper Madison Lynd' WHERE SpyID = 3";

            // Execute our queries, passing the transaction to each
            await cn.ExecuteAsync(firstUpdate, transaction: trans);
            await cn.ExecuteAsync(secondUpdate, transaction: trans);
            await cn.ExecuteAsync(thirdUpdate, transaction: trans);

            // Commit the transaction if all queries
            // executed successfully
            await trans.CommitAsync();
        }
        catch (Exception ex)
        {
            // Log the exception
            logger.LogError(ex, "An error occured during transaction");
            // Rollback changes
            await trans.RollbackAsync();
        }
    }

    // Return ok
    return Results.Ok();
});

app.MapPost("/Update/v3", async (SqlConnection cn, ILogger<Program> logger) =>
{
    // Open the connection
    await cn.OpenAsync();
    // Obtain a transaction from the connection
    await using (var trans = await cn.BeginTransactionAsync())
    {
        try
        {
            // setup our update queries
            const string firstUpdate = "UPDATE Spies SET Name = 'James Bond' WHERE SpyID = 1";
            const string secondUpdate = "UPDATE Spies SET Name = 'Eve MoneyPenny' WHERE SpyID = 2";
            const string thirdUpdate = "UPDATE Spies SET Name = 'Vesper Lynd' WHERE SpyID = 3";

            // Execute our queries, passing the transaction to each
            await cn.ExecuteAsync(firstUpdate, transaction: trans);
            await cn.ExecuteAsync(secondUpdate, transaction: trans);
            await cn.ExecuteAsync(thirdUpdate, transaction: trans);

            // throw some exception here

            throw new Exception("A random exception");

            // Commit the transaction if all queries
            // executed successfully
            await trans.CommitAsync();
        }
        catch (Exception ex)
        {
            // Log the exception
            logger.LogError(ex, "An error occured during transaction");
            // Rollback changes
            await trans.RollbackAsync();
            // Return an error response
            return Results.InternalServerError();
        }
    }

    // Return ok
    return Results.Ok();
});

app.Run();