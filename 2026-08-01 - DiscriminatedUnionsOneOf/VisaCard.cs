namespace DiscrimiantedUnions;

public sealed class VisaCard : IKnownCard
{
    public required string Number { get; init; }
    public string Type => "VISA";
    public required string CardHolderName { get; init; }
    public required string CVV { get; init; }
}