namespace UnitTestingLogic;

public sealed record UpdateSpyRequest
{
    public required string Name { get; init; }
    public required DateOnly DateOfBirth { get; init; }
    public required string Agency { get; init; }
}