namespace UnitTestingLogic;

public sealed record CreateSpyRequest
{
    public required string Name { get; set; }
    public required DateOnly DateOfBirth { get; set; }
    public required string Agency { get; set; }
}