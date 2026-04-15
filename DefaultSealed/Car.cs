public sealed class Car
{
    public required string Name { get; set; }
    public required string Model { get; set; }
    public required int YearOfManufacture { get; set; }

    public override string ToString()
    {
        return $"{Name}, {Model} ({YearOfManufacture})";
    }
}