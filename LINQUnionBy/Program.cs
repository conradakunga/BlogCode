Agent[] agents1980 =
[
    new() { Name = "James Bond", Age = 40 },
    new() { Name = "Jason Bourne", Age = 37 },
    new() { Name = "Evelyn Salt", Age = 28 },
    new() { Name = "Ros Myers", Age = 25 },
];


Agent[] agents1990 =
[
    new() { Name = "James Bond", Age = 50 },
    new() { Name = "Jason Bourne", Age = 45 },
    new() { Name = "Evelyn Salt", Age = 35 },
    new() { Name = "Ros Myers", Age = 30 },
    new() { Name = "Ethan Hunt", Age = 40 },
    new() { Name = "Benji Dunn", Age = 30 },
    new() { Name = "Luther Stickell", Age = 37 },
];

// Union both lists
var allAgents = agents1990.Union(agents1980).ToList();
// Print to console
//allAgents.ForEach(x => Console.WriteLine($"Agent: {x.Name}, Age: {x.Age}"));


// Union both lists, using the Name for uniqueness
allAgents = agents1990.UnionBy(agents1980, element => element.Name).ToList();
// Print to console
allAgents.ForEach(x => Console.WriteLine($"Agent: {x.Name}, Age: {x.Age}"));