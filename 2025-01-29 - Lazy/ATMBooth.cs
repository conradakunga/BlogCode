public sealed class ATMBooth
{
    // Indicate we need lazy initialization for our ATM
    private Lazy<ATM> _atm;

    public ATMBooth()
    {
        // Lazily initiate our ATM, and indicate we want it thread-safe
        _atm = new Lazy<ATM>(() => new ATM(10_000), true);
    }

    // Return the value from our Lazy object when requested
    public ATM ATM => _atm.Value;
}