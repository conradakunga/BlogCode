
// Create a queue of agents
var agents = new Queue<Agent>();

// Enqueue 3 agents
agents.Enqueue(new Agent() { Name = "James Bond" });
agents.Enqueue(new Agent() { Name = "Jason Bourne" });
agents.Enqueue(new Agent() { Name = "Evelyn Salt" });

// Pop all the agents
while (agents.TryDequeue(out var agent))
{
    Console.WriteLine($"Popping agent {agent.Name}");
}

// Create a priority queue of agents
var prioritizedAgents = new PriorityQueue<Agent, int>();

// Enqueue 3 agents, specifying their effectiveness
prioritizedAgents.Enqueue(new Agent() { Name = "James Bond" }, 95);
prioritizedAgents.Enqueue(new Agent() { Name = "Jason Bourne" }, 85);
prioritizedAgents.Enqueue(new Agent() { Name = "Evelyn Salt" }, 90);

// Pop all the agents
while (prioritizedAgents.TryDequeue(out var agent, out var effectiveness))
{
    Console.WriteLine($"Popping agent {agent.Name}, who has effectiveness of {effectiveness}");
}

var sergeant = new Rank() { Name = "Sergeant", Weight = 1 };
var lieutenant = new Rank() { Name = "Lieutenant", Weight = 2 };
var major = new Rank() { Name = "Major", Weight = 3 };
var colonel = new Rank() { Name = "Colonel", Weight = 4 };

var soldiersToServe = new PriorityQueue<Soldier, Rank>(new RankComparable());
soldiersToServe.Enqueue(new Soldier() { Name = "John" }, sergeant);
soldiersToServe.Enqueue(new Soldier() { Name = "Mary" }, lieutenant);
soldiersToServe.Enqueue(new Soldier() { Name = "Anne" }, major);
soldiersToServe.Enqueue(new Soldier() { Name = "Jeff" }, colonel);

// Pop all the agents
while (soldiersToServe.TryDequeue(out var soldier, out var rank))
{
    Console.WriteLine($"Serving agent {soldier.Name}, a {rank.Name}");
}

public class Soldier
{
    public string Name { get; set; }
}

public class Agent
{
    public string Name { get; set; }
}