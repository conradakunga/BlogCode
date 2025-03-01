using System.Data;
using Bogus;
using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "data source=10.211.55.2;database=Spies;uid=sa;pwd=YourStrongPassword123;Encrypt=false";

var builder = WebApplication.CreateBuilder(args);

// Setup DI to inject a Sql Server connection
builder.Services.AddSingleton<SqlConnection>(_ => new SqlConnection(connectionString));

var app = builder.Build();

app.MapPost("/Spy/", async (SqlConnection cn, Spy spy) =>
{
    var param = new DynamicParameters();
    param.Add("Name", spy.Name);
    param.Add("DateOfBirth", spy.DateOfBirth);
    param.Add("Height", spy.Height);
    param.Add("Active", spy.Active);
    param.Add("SpyID", dbType: DbType.Int32, direction: ParameterDirection.Output);

    await cn.ExecuteAsync("[Spies.Create]", param);

    // Capture the new SpyID from the output parameter
    var newID = param.Get<int>("SpyID");
    // Set it in our Spy object
    spy.SpyID = newID;
    // Return a 201 with the spy in the body 
    return Results.Created($"/Spy/{newID}", spy);
});

app.MapGet("/Spy/{id:int}", async (SqlConnection cn, int id) =>
{
    const string query = """
                         SELECT
                             Spies.SpyID,
                             Spies.Name,
                             Spies.DateOfBirth,
                             Spies.Height,
                             Spies.Active
                         FROM
                             dbo.Spies WHERE Spies.SpyID = @SpyID
                         """;
    var param = new DynamicParameters();
    param.Add("SpyID", id);

    var spy = await cn.QuerySingleOrDefaultAsync<Spy>(query, param);

    if (spy == null)
        return Results.NotFound();

    return Results.Ok(spy);
});

app.MapGet("/Seed/v1", async (SqlConnection cn) =>
{
    // Create a faker object
    var faker = new Faker<Spy>();

    //
    // Configure our faker
    //

    // SpyID should always be -1, because the DB is generating them
    faker.RuleFor(x => x.SpyID, -1);
    // Generate realistic names
    faker.RuleFor(x => x.Name, f => f.Person.FullName);
    // Date of birth should be random date in the past, max 50 years go
    faker.RuleFor(x => x.DateOfBirth, y => y.Date.Past(50));
    // Active should always be true
    faker.RuleFor(x => x.Active, true);
    // Height should be between 5 feet and 6'3
    faker.RuleFor(x => x.Height, y => y.Random.Decimal(5.0M, 6.2M));

    // Generate our spies
    var spies = faker.Generate(100);
    // Loop through the collection and insert
    foreach (var spy in spies)
    {
        // Populate our parameters
        var param = new DynamicParameters();
        param.Add("Name", spy.Name);
        param.Add("DateOfBirth", spy.DateOfBirth);
        param.Add("Height", spy.Height);
        param.Add("Active", spy.Active);
        param.Add("SpyID", dbType: DbType.Int32, direction: ParameterDirection.Output);

        // Execute the query
        await cn.ExecuteAsync("[Spies.Create]", param);
    }

    return Results.Ok();
});

app.MapGet("/Seed/v2", async (SqlConnection cn) =>
{
    // Create a faker object
    var faker = new Faker<Spy>();

    //
    // Configure our faker
    //

    // SpyID should always be -1, because the DB is generating them
    faker.RuleFor(x => x.SpyID, -1);
    // Generate realistic names
    faker.RuleFor(x => x.Name, f => f.Person.FullName);
    // Date of birth should be random date in the past, max 50 years go
    faker.RuleFor(x => x.DateOfBirth, y => y.Date.Past(50));
    // Active should always be true
    faker.RuleFor(x => x.Active, true);
    // Height should be between 5 feet and 6'3
    faker.RuleFor(x => x.Height, y => y.Random.Decimal(5.0M, 6.2M));

    // Generate our spies
    var spies = faker.Generate(100);

    // Create a datatable

    var dt = new DataTable();

    // Add columns
    dt.Columns.Add("Name", typeof(string));
    dt.Columns.Add("DateOfBirth", typeof(DateTime));
    dt.Columns.Add("Height", typeof(decimal));
    dt.Columns.Add("Active", typeof(bool));

    // Loop through the collection, create a datarow,
    // populate it with data and add it to he rows
    // collection of the datarow

    foreach (var spy in spies)
    {
        var row = dt.NewRow();
        row["Name"] = spy.Name;
        row["DateOfBirth"] = spy.DateOfBirth;
        row["Height"] = spy.Height;
        row["Active"] = spy.Active;
        dt.Rows.Add(row);
    }

    // Populate our parameters
    var param = new DynamicParameters();
    param.Add("Spies", dt.AsTableValuedParameter());
    
    // Execute the query
    await cn.ExecuteAsync("[Spies.BulkCreate]", param);
    return Results.Ok();
});
app.Run();