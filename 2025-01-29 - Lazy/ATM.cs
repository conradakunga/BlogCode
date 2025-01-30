using Serilog;

public sealed class ATM
{
    public decimal Balance { get; private set; }

    public ATM(decimal balance)
    {
        // Simulate a lengthy process
        Thread.Sleep(TimeSpan.FromSeconds(30));
        Balance = balance;
        Log.Information("ATM Ready ...");
    }

    public void Withdraw(decimal amount)
    {
        if (amount < Balance)
        {
            Log.Information("Withdrawing  {Amount:#,0.00}", amount);
            Balance -= amount;
        }
        else
            Log.Error($"Insufficient ATM balance");
    }

    public void Deposit(decimal amount)
    {
        Log.Information("Depositing {amount:#,0.00}", amount);
        Balance += amount;
    }
}