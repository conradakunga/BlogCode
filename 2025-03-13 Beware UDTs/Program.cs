using System.Data;
using Bogus;
using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "data source=10.211.55.2;database=Spies;uid=sa;pwd=YourStrongPassword123;Encrypt=false";

var builder = WebApplication.CreateBuilder(args);

// Setup DI to inject a Sql Server connection
builder.Services.AddSingleton<SqlConnection>(_ => new SqlConnection(connectionString));

var app = builder.Build();

app.MapGet("/Insert", async (SqlConnection cn) =>
{
    // Create a data table for mapping
    var dt = new DataTable();
    dt.Columns.Add("UserID", typeof(int));
    dt.Columns.Add("Timeout", typeof(int));
    dt.Columns.Add("Username", typeof(string));
    dt.Columns.Add("Notes", typeof(string));

    // Create our faker

    // Initialize a counter
    var counter = 0;

    var faker = new Faker<User>()
        // Auto number the user id from 0
        .RuleFor(u => u.UserID, f => ++counter)
        // Set the timout to be a random number between 0 and 100
        .RuleFor(u => u.Timeout, f => f.Random.Int(0, 100))
        // Generate a realistic user name
        .RuleFor(u => u.Username, f => f.Person.UserName)
        // Generate lorem notes
        .RuleFor(u => u.Notes, f => f.Lorem.Sentence(3));

    // Generate 15 users
    var users = faker.Generate(15);

    // Add to our datatable
    foreach (var user in users)
    {
        var row = dt.NewRow();
        row["UserID"] = user.UserID;
        row["Timeout"] = user.Timeout;
        row["Username"] = user.Username;
        row["Notes"] = user.Notes;
        dt.Rows.Add(row);
    }

    // Setup dapper
    var param = new DynamicParameters();
    param.Add("Users", dt.AsTableValuedParameter());
    await cn.ExecuteAsync("[Users.Insert]", param);

    return Results.Ok();
});

app.MapGet("/InsertBug", async (SqlConnection cn) =>
{
    // Create a data table for mapping, swapping the order
    var dt = new DataTable();
    dt.Columns.Add("Timeout", typeof(int));
    dt.Columns.Add("UserID", typeof(int));
    dt.Columns.Add("Username", typeof(string));
    dt.Columns.Add("Notes", typeof(string));

    // Create our faker

    // Initialize a counter from 100
    var counter = 100;

    var faker = new Faker<User>()
        // Auto number the user id from 0
        .RuleFor(u => u.UserID, f => ++counter)
        // Set the timout to be a random number between 0 and 100
        .RuleFor(u => u.Timeout, f => f.Random.Int(0, 100))
        // Generate a realistic username
        .RuleFor(u => u.Username, f => f.Person.UserName)
        // Generate lorem notes
        .RuleFor(u => u.Notes, f => f.Lorem.Sentence(3));

    // Generate 15 users
    var users = faker.Generate(15);

    // Add to our datatable
    foreach (var user in users)
    {
        var row = dt.NewRow();
        row["UserID"] = user.UserID;
        row["Timeout"] = user.Timeout;
        row["Username"] = user.Username;
        row["Notes"] = user.Notes;
        dt.Rows.Add(row);
    }

    // Setup dapper
    var param = new DynamicParameters();
    param.Add("Users", dt.AsTableValuedParameter());
    await cn.ExecuteAsync("[Users.Insert]", param);

    return Results.Ok();
});

app.Run();