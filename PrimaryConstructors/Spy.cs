public class Spy
{
    public string Name { get; }
    public string Agency { get; }

    public Spy(string name, string agency)
    {
        Name = name;
        Agency = agency;
    }

    public string PrintIdentification()
    {
        return $"Name: {Name}; Agency: {Agency}";
    }
}