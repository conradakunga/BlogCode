using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "data source=.;database=Spies;uid=sa;pwd=YourStrongPassword123;Encrypt=false";

var builder = WebApplication.CreateBuilder(args);

// Setup DI to inject a Sql Server connection
builder.Services.AddSingleton<SqlConnection>(_ => new SqlConnection(connectionString));

var app = builder.Build();

app.MapGet("/", async (SqlConnection cn) =>
{
    List<Agent> agents = [];
    List<FieldAgent> fieldAgents = [];

    const string sql = """
                       SELECT
                           Agents.AgentID,
                           Agents.Name,
                           Agents.DateOfBirth,
                           Agents.CountryOfPosting,
                           Agents.HasDiplomaticCover,
                           Agents.AgentType
                       FROM
                           dbo.Agents;
                       """;
    await using (var reader = await cn.ExecuteReaderAsync(sql))
    {
        // Declare parsers
        var agentsParser = reader.GetRowParser<Agent>();
        var fieldAgentsParser = reader.GetRowParser<FieldAgent>();

        while (reader.Read())
        {
            // Read our discriminating column value
            var discriminator = (AgentType)reader.GetInt32(reader.GetOrdinal(nameof(AgentType)));
            // Use discriminator to parse rows
            switch (discriminator)
            {
                case AgentType.Agent:
                    agents.Add(agentsParser(reader));
                    break;
                case AgentType.Field:
                    fieldAgents.Add(fieldAgentsParser(reader));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(discriminator), "Invalid agent type");
            }
        }
    }

    // Output the results
    return new { Agents = agents, FieldAgents = fieldAgents };
});

app.Run();