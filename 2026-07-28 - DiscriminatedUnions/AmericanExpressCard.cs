namespace v1
{
    public sealed class AmericanExpressCard
    {
        public required string Number { get; init; }
        public required string CVV { get; init; }
        public required string CardHolderName { get; init; }
    }
}

namespace v3
{
    public class AmericanExpressCard : Card
    {
        public override string Type => "American Express";
    }
}