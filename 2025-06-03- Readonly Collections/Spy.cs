public sealed class Spy
{
    private readonly List<string> _agencies = [];
    public IEnumerable<string> Agencies => _agencies.AsReadOnly();
    public required string FirstName { get; init; }
    public required string Surname { get; init; }
    private readonly string[] _stations = ["London", "Barbados", "Jamaica"];
    public IEnumerable<string> Stations => _stations.AsReadOnly();

    public void AddAgency(string agency)
    {
        if (!_agencies.Contains(agency))
            _agencies.Add(agency);
    }
}