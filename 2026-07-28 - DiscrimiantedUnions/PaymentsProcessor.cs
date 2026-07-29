using v1;

namespace v1
{
    public static class PaymentsProcessor
    {
        public static void MakePayment(Card card, decimal Amount)
        {
            Console.WriteLine($"A payment of {Amount:#,0.00} was made by VISA card ending in XXXX-{card.Number[^4..]}");
        }
    }
}

namespace v2
{
    public static class PaymentsProcessor
    {
        public static void MakePayment(VisaCard card, decimal Amount)
        {
            Console.WriteLine($"A payment of {Amount:#,0.00} was made by VISA card ending in XXXX-{card.Number[^4..]}");
        }

        public static void MakePayment(AmericanExpressCard card, decimal Amount)
        {
            Console.WriteLine($"A payment of {Amount:#,0.00} was made by AMEX card ending in XXXX-{card.Number[^4..]}");
        }
    }
}

namespace v3
{
    public static class PaymentsProcessor
    {
        public static void MakePayment(Card card, decimal Amount)
        {
            switch (card)
            {
                case VisaCard:
                    Console.WriteLine(
                        $"A payment of {Amount:#,0.00} was made by VISA card ending in XXXX-{card.Number[^4..]}");
                    break;
                case AmericanExpressCard:
                    Console.WriteLine(
                        $"A payment of {Amount:#,0.00} was made by American Express card ending in XXXX-{card.Number[^4..]}");
                    break;
            }
        }
    }
}