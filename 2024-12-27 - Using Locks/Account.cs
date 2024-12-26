namespace LockingSupport;

public sealed class Account
{
    private readonly Lock _lock = new();
    public decimal Balance { get; private set; }

    public void Deposit(decimal amount)
    {
        lock (_lock)
        {
            Balance += amount;
        }
    }

    public void Withdraw(decimal amount)
    {
        using (_lock.EnterScope())
        {
            Balance -= amount;
        }
    }
}