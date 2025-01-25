Agency[] agencies =
[
    new Agency { AgencyID = 1, Name = "MI-6" },
    new Agency { AgencyID = 2, Name = "MI-5" },
    new Agency { AgencyID = 3, Name = "IMF" },
    new Agency { AgencyID = 4, Name = "CIA" },
];

Agent[] agents =
[
    new Agent { AgentID = 1, AgencyID = 1, Name = "George Smiley" },
    new Agent { AgentID = 2, AgencyID = 1, Name = "James Bond" },
    new Agent { AgentID = 3, AgencyID = 2, Name = "Harry Pearce" },
    new Agent { AgentID = 4, AgencyID = 2, Name = "Roz Myers" },
    new Agent { AgentID = 5, AgencyID = 3, Name = "Ethan Hunt" },
    new Agent { AgentID = 6, AgencyID = 3, Name = "Luther Stickell" },
    new Agent { AgentID = 7, AgencyID = 3, Name = "Benji Dunn" },
    new Agent { AgentID = 8, AgencyID = 4, Name = "Eveylyn Salt" },
    new Agent { AgentID = 9, AgencyID = 4, Name = "Jason Bourne" },
];

// Perform the Join and return an array
var results1 = agencies.GroupJoin(
    agents,
    agency => agency.AgencyID, // Outer key 
    agent => agent.AgencyID, // Inner key 
    (agencyResult, agentsResult) => new //Project into a new anonymous type
    {
        Agency = agencyResult.Name,
        Agents = agentsResult.Select(x => x.Name)
    }
).ToArray();

foreach (var result in results1)
{
    Console.WriteLine($"Agency: {result.Agency}");
    foreach (var agent in result.Agents)
    {
        Console.WriteLine($"\tAgent: {agent}");
    }
}

// Perform the Join and return an array
var results = agencies.GroupJoin(
    agents,
    agency => agency.AgencyID, // Outer key 
    agent => agent.AgencyID, // Inner key 
    (agencyResult, agentsResult) => new // Project into a new anonymous type
    {
        Agency = agencyResult,
        Agents = agentsResult
    }
).ToArray();

foreach (var result in results)
{
    Console.WriteLine($"Agency: {result.Agency.Name} (ID - {result.Agency.AgencyID})");
    foreach (var agent in result.Agents)
    {
        Console.WriteLine($"\tAgent: {agent.Name} (AgentID - {agent.AgentID})");
    }
}


public sealed record Agent
{
    public required int AgentID { get; init; }
    public required int AgencyID { get; init; }
    public required string Name { get; init; }
}

public sealed record Agency
{
    public required int AgencyID { get; init; }
    public required string Name { get; init; }
}