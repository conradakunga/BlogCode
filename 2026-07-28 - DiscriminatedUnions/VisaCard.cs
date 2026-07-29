namespace v1
{
    public sealed class VisaCard
    {
        public required string Number { get; init; }
        public required string CVV { get; init; }
        public required string CardHolderName { get; init; }
    }
}

namespace v3
{
    public class VisaCard : Card
    {
        public override string Type => "VISA";
    }
}