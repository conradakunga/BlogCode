public sealed class AtmBoothV3
{
    // Initially this is null
    private ATM? _atm;
    private readonly Lock _lock = new();

    public ATM ATM
    {
        get
        {
            if (_atm == null)
            {
                // Do our null check & creation in a scope
                using (_lock.EnterScope())
                {
                    // Check if the field is null
                    if (_atm == null)
                    {
                        // If it is, create a new one
                        _atm = new ATM(100_000);
                    }
                }
            }

            // Return the field
            return _atm;
        }
    }
}