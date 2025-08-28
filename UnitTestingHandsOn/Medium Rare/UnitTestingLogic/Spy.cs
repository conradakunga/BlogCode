namespace UnitTestingLogic;

public sealed record Spy
{
    public required Guid SpyID { get; set; }
    public required string Name { get; set; }
    public required DateOnly DateOfBirth { get; set; }
    public required string Agency { get; set; }
}