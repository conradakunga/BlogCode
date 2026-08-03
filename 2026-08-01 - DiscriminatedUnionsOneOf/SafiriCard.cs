namespace DiscrimiantedUnions;

public sealed class SafiriCard : ICard
{
    public required string Number { get; init; }
    public string Type => "Safiri";
    public required string CardHolderName { get; init; }
}