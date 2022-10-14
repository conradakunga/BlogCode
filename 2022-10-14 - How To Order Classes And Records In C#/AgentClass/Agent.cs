record Agent : IComparer<Agent>, IComparable<Agent>
{
    public string FirstName { get; }
    public string Surname { get; }
    public Agent(string firstName, string surname)
    {
        Surname = surname;
        FirstName = firstName;

    }
    public int Compare(Agent a1, Agent a2)
    {
        var sCompare = a1.Surname.CompareTo(a2.Surname);
        if (sCompare == 0) // surnames match. Compare first names
            return a1.FirstName.CompareTo(a2.FirstName);
        else
            return sCompare;
    }
    public int CompareTo(Agent other)
    {
        return this.Compare(this, other);
    }
}