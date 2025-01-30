public sealed class AtmBoothV2
{
    // Initially this is null
    private ATM? _atm;

    public ATM ATM
    {
        get
        {
            // Check if the field is null
            if (_atm == null)
            {
                // If it is, create a new one
                _atm = new ATM(100_000);
            }

            // Return the field
            return _atm;
        }
    }
}