// Design #1

{
    var card = new v1.Card
    {
        Number = "0123-4567-8901",
        CardHolderName = "Conrad Akunga",
        CVV = "342"
    };


    v1.PaymentsProcessor.MakePayment(card, 10_000);
}

// Design #2

{
    var amex = new v1.AmericanExpressCard
    {
        CardHolderName = "Conrad Akunga",
        CVV = "3423",
        Number = "0100-3224-2344-23234"
    };

    var visa = new v1.VisaCard
    {
        CardHolderName = "Conrad Akunga",
        CVV = "45354",
        Number = "1234-5678-9190-34234"
    };

    v2.PaymentsProcessor.MakePayment(visa, 10_000);
    v2.PaymentsProcessor.MakePayment(amex, 15_000);
}

// Design #3

{
    var amex = new v3.AmericanExpressCard
    {
        CardHolderName = "Conrad Akunga",
        CVV = "3423",
        Number = "0100-3224-2344-23234"
    };

    var visa = new v3.VisaCard
    {
        CardHolderName = "Conrad Akunga",
        CVV = "45354",
        Number = "1234-5678-9190-34234"
    };

    v3.PaymentsProcessor.MakePayment(visa, 10_000);
    v3.PaymentsProcessor.MakePayment(amex, 15_000);
}