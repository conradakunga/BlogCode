namespace v1
{
    public sealed class Card
    {
        public required string Number { get; init; }
        public required string CVV { get; init; }
        public required string CardHolderName { get; init; }
    }
}

namespace v3
{
    public abstract class Card
    {
        public required string Number { get; init; }
        public abstract string Type { get; }
        public required string CVV { get; init; }
        public required string CardHolderName { get; init; }
    }
}