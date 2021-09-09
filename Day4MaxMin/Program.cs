var agents = new Agent[] {
    new Agent() { Name = "James Bond", Age = 40 } ,
    new Agent() { Name = "Jason Bourne", Age = 35 } ,
    new Agent() { Name = "Evelyn Salt", Age = 30 }
};

// filter agents older than 35
var candidates = agents.Where(agent => agent.Age >= 35);
foreach (var candidate in candidates)
{
    Console.WriteLine(candidate.Name);
}

// get the oldest agent  - old way
var oldestV1 = agents.OrderByDescending(agent => agent.Age).First();
Console.WriteLine(oldestV1.Name);

// get the oldest agent - MaxBy
var oldestV2 = agents.MaxBy(agent => agent.Age);
Console.WriteLine(oldestV2.Name);

// get the youngest agent - MinBy
var youngest = agents.MinBy(agent => agent.Age);
Console.WriteLine(youngest.Name);

// The agent with the longest name
var longestName = agents.MaxBy(agent => agent.Name.Length);
Console.WriteLine(longestName.Name);

// The agent with the shortest name
var shortestName = agents.MinBy(agent => agent.Name.Length);
Console.WriteLine(shortestName.Name);