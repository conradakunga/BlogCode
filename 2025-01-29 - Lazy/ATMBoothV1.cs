public sealed class ATMBoothV1
{
    public ATM ATM { get; }

    public ATMBoothV1()
    {
        ATM = new ATM(100_000);
    }
}