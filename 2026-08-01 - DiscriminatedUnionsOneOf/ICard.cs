namespace DiscrimiantedUnions;

public interface ICard
{
    public string Number { get; init; }
    public string Type { get; }
    public string CardHolderName { get; init; }
}