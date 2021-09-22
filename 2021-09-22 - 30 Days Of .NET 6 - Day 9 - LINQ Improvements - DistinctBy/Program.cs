var agents = new[]
{
    new Agent() {Name = "Ethan Hunt", Age = 40},
    new Agent() {Name = "James Bond", Age = 40},
    new Agent() {Name = "Jason Bourne", Age = 35},
    new Agent() {Name = "Evelyn Salt", Age = 30},
    new Agent() {Name = "Jack Ryan", Age = 36},
    new Agent() {Name = "Jane Smith", Age = 35},
    new Agent() {Name = "Oren Ishii", Age = 30},
    new Agent() {Name = "Natasha Romanoff", Age = 33}
};

var ages = new[] { 30, 33, 35, 36, 40, 30, 33, 36, 30, 40 };

var uniqueAges = ages.Distinct().ToArray();

foreach (var age in uniqueAges)
{
    Console.Write($"{age} ");
}

var distinctAgents = agents.DistinctBy(x => x.Age).OrderBy(x=>x.Name);
foreach (var agent in distinctAgents)
{
    Console.WriteLine($"Agent {agent.Name} is {agent.Age}");
}



public record Agent
{
	public string Name { get; init; }
	public byte Age { get; init; }
}