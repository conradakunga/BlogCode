using Bogus;
using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "data source=10.211.55.2;database=Spies;uid=sa;pwd=YourStrongPassword123;Encrypt=false";

var builder = WebApplication.CreateBuilder(args);

// Setup DI to inject a Sql Server connection
builder.Services.AddSingleton<SqlConnection>(_ => new SqlConnection(connectionString));

var app = builder.Build();

app.MapPost("/", async (SqlConnection cn) =>
{
    // Create query to insert
    const string sql = """
                       INSERT dbo.Agents
                           (
                               Name,
                               DateOfBirth,
                               CountryOfPosting,
                               HasDiplomaticCover,
                               AgentType
                           )
                       VALUES
                           (
                               @Name, @DateOfBirth, @CountryOfPosting, @HasDiplomaticCover, @AgentType
                           ) 
                       """;
    // Configure bogus
    var faker = new Faker<FieldAgent>();
    // Generate a full name
    faker.RuleFor(x => x.Name, f => f.Name.FullName());
    // Date of birth, max 90 years go
    faker.RuleFor(x => x.DateOfBirth, f => f.Date.Past(90));
    // Country of posting
    faker.RuleFor(x => x.CountryOfPosting, f => f.Address.Country());
    // Randomly assign diplomatic cover
    faker.RuleFor(x => x.HasDiplomaticCover, f => f.Random.Bool());
    // Agent type is field
    faker.RuleFor(x => x.AgentType, AgentType.Field);

    // Generate  a list of 100 field agents
    var fieldAgents = faker.Generate(100);
    // Now execute the query, and capture the inserted rows
    var inserted = await cn.ExecuteAsync(sql, fieldAgents);

    return inserted;
});

app.Run();