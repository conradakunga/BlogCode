using DiscrimiantedUnions;

var amex = new AmericanExpressCard
{
    CardHolderName = "Conrad Akunga",
    CVV = "3423",
    Number = "0100-3224-2344-23234"
};

PaymentsProcessor.MakePayment(amex, 10_000);

var visa = new VisaCard
{
    CardHolderName = "Conrad Akunga",
    CVV = "45354",
    Number = "1234-5678-9190-34234"
};
PaymentsProcessor.MakePayment(visa, 10_000);

var safiri = new SafiriCard
{
    Number = "2343-3423-2342-5646",
    CardHolderName = "Conrad Akunga",
};
PaymentsProcessor.MakePayment(safiri, 10_000);

var mpesa = new MobileMoneyPayment
{
    PhoneNumber = "254-721-345-345",
    Name = "Conrad Akunga"
};

PaymentsProcessor.MakePayment(mpesa, 10_000);