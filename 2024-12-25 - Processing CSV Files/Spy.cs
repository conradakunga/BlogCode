using CsvHelper.Configuration.Attributes;

public record Spy
{
    public required string Name { get; init; }
    public required int Age { get; init; }
    public required string Service { get; init; }
}