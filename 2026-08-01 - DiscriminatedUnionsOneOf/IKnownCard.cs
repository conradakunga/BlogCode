namespace DiscrimiantedUnions;

public interface IKnownCard : ICard
{
    public string CVV { get; init; }
}