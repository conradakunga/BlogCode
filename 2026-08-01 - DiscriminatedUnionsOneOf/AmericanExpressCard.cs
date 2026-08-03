namespace DiscrimiantedUnions;

public sealed class AmericanExpressCard : IKnownCard
{
    public required string Number { get; init; }
    public string Type => "American Express";
    public required string CardHolderName { get; init; }
    public required string CVV { get; init; }
}