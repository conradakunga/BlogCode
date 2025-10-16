public sealed record Animal
{
    public required string Name { get; init; }
    public required AnimalType AnimalType { get; init; }
}