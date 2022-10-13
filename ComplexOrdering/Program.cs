var agents = new Agent[] { new Agent("James", "Bond"), new Agent("Evelyn", "Salt"), new Agent("Jason", "Bourne"), new Agent("Jane", "Bond") };
//agents.Order(new AgentComparer()).Dump();

//var orderedAgents = agents.OrderBy(agent => agent).ToList();

var orderedAgents = agents.OrderBy(agent => agent.Surname)
    .ThenBy(agent => agent.FirstName).ToList();

PrintCollection(orderedAgents);

// Order using the comparer
var newlyOrderedAgents = agents.OrderBy(agent => agent, new AgentComparer()).ToList();

PrintCollection(newlyOrderedAgents);

// Order using the comparer (new syntax)
var moreNewlyOrderedAgents = agents.Order(new AgentComparer()).ToList();

PrintCollection(moreNewlyOrderedAgents);

// reverse sorting
PrintCollection(agents.OrderDescending(new AgentComparer()).ToList());

void PrintCollection<T>(List<T> collection)
{
    collection.ForEach(item => Console.WriteLine(item));
    Console.WriteLine();
}
record Agent(string FirstName, string Surname);

class AgentComparer : IComparer<Agent>
{
    public int Compare(Agent a1, Agent a2)
    {
        var sCompare = a1.Surname.CompareTo(a2.Surname);
        if (sCompare == 0) // surnames match. Compare first names
            return a1.FirstName.CompareTo(a2.Surname);
        else
            return sCompare;
    }
}