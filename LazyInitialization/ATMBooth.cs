public sealed class ATMBooth
{
    public ATM ATM { get; }

    public ATMBooth()
    {
        ATM = new ATM(100_000);
    }
}