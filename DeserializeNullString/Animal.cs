namespace DeserializeNullString;

public record Animal
{
    // The animal name may be null
    public string? Name { get; set; }

    // The number of legs cannot be null
    public int Legs { get; set; }
}