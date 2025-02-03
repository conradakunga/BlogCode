Agent[] legacy =
[
    new() { Name = "Jason Bourne", DateOfBirth = new DateOnly(1970, 1, 1) },
    new() { Name = "James Bond", DateOfBirth = new DateOnly(1950, 1, 1) },
    new() { Name = "Evelyn Salt", DateOfBirth = new DateOnly(1980, 1, 1) },
    new() { Name = "Vesper Lynd", DateOfBirth = new DateOnly(1960, 1, 1) },
    new() { Name = "Eve MoneyPenny", DateOfBirth = new DateOnly(1990, 1, 1) }
];

Agent[] current =
[
    new() { Name = "Eve MoneyPenny", DateOfBirth = new DateOnly(1990, 1, 1) },
    new() { Name = "Evelyn Salt", DateOfBirth = new DateOnly(1980, 1, 1) },
    new() { Name = "Ethan Hunt", DateOfBirth = new DateOnly(1970, 1, 1) },
    new() { Name = "Luther Stickell", DateOfBirth = new DateOnly(1970, 1, 1) },
    new() { Name = "Benji Dunn", DateOfBirth = new DateOnly(1985, 1, 1) },
];

// Union both collectoons
var allAgents = legacy.Union(current).ToList();
// Print to console
//allAgents.ForEach(agent => Console.WriteLine($"{agent.Name}, born on {agent.DateOfBirth}"));


// Concat both collections
allAgents = legacy.Concat(current).ToList();
// Print to console
allAgents.ForEach(agent => Console.WriteLine($"{agent.Name}, born on {agent.DateOfBirth}"));

