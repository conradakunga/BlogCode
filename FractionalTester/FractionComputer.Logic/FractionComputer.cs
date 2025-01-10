namespace PercentageComputer.Logic;

public class FractionComputer
{
    public decimal Compute(decimal numerator, decimal denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Denominator cannot be zero.");
        return numerator / denominator;
    }
}