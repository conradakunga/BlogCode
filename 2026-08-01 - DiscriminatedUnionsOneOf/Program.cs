using DiscrimiantedUnions;

var amex = new AmericanExpressCard
{
    CardHolderName = "Conrad Akunga",
    CVV = "3423",
    Number = "0100-3224-2344-23234"
};

var visa = new VisaCard
{
    CardHolderName = "Conrad Akunga",
    CVV = "45354",
    Number = "1234-5678-9190-34234"
};

var safiri = new SafiriCard
{
    Number = "2343-3423-2342-5646",
    CardHolderName = "Conrad Akunga",
};