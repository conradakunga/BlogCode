var agents = new Agent[] { new Agent("James", "Bond"), new Agent("Evelyn", "Salt"), new Agent("Jason", "Bourne"), new Agent("Jane", "Bond") };

var orderedAgents = agents.OrderBy(agent => agent.Surname)
    .ThenBy(agent => agent.FirstName).ToList();

PrintCollection(orderedAgents);

// Order using the comparer
var newlyOrderedAgents = agents.OrderBy(agent => agent).ToList();

PrintCollection(newlyOrderedAgents);

// Order using the comparer (new syntax)
var moreNewlyOrderedAgents = agents.Order().ToList();

PrintCollection(moreNewlyOrderedAgents);

// reverse sorting
PrintCollection(agents.OrderDescending().ToList());

void PrintCollection<T>(List<T> collection)
{
    collection.ForEach(item => Console.WriteLine(item));
    Console.WriteLine();
}