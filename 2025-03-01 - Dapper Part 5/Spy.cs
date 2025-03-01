public sealed class Spy
{
    // Unlike the other properties, this is mutable
    public int SpyID { get; set; }
    public required string Name { get; init; }
    public required DateTime DateOfBirth { get; init; }
    public required decimal Height { get; init; }
    public required bool Active { get; init; }
}