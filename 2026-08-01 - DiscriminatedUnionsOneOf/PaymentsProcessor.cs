using OneOf;

namespace DiscrimiantedUnions;

public static class PaymentsProcessor
{
    public static void MakePayment(OneOf<AmericanExpressCard, VisaCard, SafiriCard, MobileMoneyPayment> payment,
        decimal Amount)
    {
        payment.Switch(
            amex =>
            {
                Console.WriteLine(
                    $"Processing payment for American Express Card {amex.Number[^4..]} of {Amount:#,0.00}");
            },
            visa => { Console.WriteLine($"Processing payment for VISA Card {visa.Number[^4..]} of {Amount:#,0.00}"); },
            safiri =>
            {
                Console.WriteLine($"Processing payment for Safiri Card {safiri.Number[^4..]} of {Amount:#,0.00}");
            },
            mobileMoney =>
            {
                Console.WriteLine(
                    $"Processing payment for Mobile money for number {mobileMoney.PhoneNumber} of {Amount:#,0.00}");
            }
        );
    }
}