namespace UnitTestingLogic;

public sealed record CreateSpyRequest
{
    public required string Name { get; init; }
    public required DateOnly DateOfBirth { get; init; }
    public required string Agency { get; init; }
}