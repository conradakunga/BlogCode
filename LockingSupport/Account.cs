namespace LockingSupport;

public sealed class Account
{
    public decimal Balance { get; private set; }

    public async Task Deposit(decimal amount)
    {
        // Simulate work to increment balance
        await Task.Delay(TimeSpan.FromSeconds(1));
        Balance += amount;
    }

    public async Task Withdraw(decimal amount)
    {
        // Simulate work to decrement balance
        await Task.Delay(TimeSpan.FromSeconds(1));
        Balance -= amount;
    }
}