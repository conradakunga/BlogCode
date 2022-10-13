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

// Advanced comparer, surname first
PrintCollection(agents.Order(new AgentAdvancedComparer(Comparison.SurnameThenFirstName)).ToList());

// Advanced comparer, first name first
PrintCollection(agents.Order(new AgentAdvancedComparer(Comparison.FirstNameThenSurname)).ToList());

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
            return a1.FirstName.CompareTo(a2.FirstName);
        else
            return sCompare;
    }
}
enum Comparison
{
    FirstNameThenSurname,
    SurnameThenFirstName
}
/// <summary>
/// This comparer allows specification of how to sort
/// </summary>
class AgentAdvancedComparer : IComparer<Agent>
{
    private readonly Comparison _comparison;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="comparison">Enum of how the sorting is to be done</param>
    public AgentAdvancedComparer(Comparison comparison)
    {
        _comparison = comparison;
    }
    public int Compare(Agent a1, Agent a2)
    {
        switch (_comparison)
        {
            case Comparison.FirstNameThenSurname:
                var fCompare = a1.FirstName.CompareTo(a2.FirstName);
                if (fCompare == 0) // first names match. Compare surnames
                    return a1.Surname.CompareTo(a2.Surname);
                else
                    return fCompare; ;
            default:
                var sCompare = a1.Surname.CompareTo(a2.Surname);
                if (sCompare == 0) // surnames match. Compare first names
                    return a1.FirstName.CompareTo(a2.FirstName);
                else
                    return sCompare;
        }
    }
}