using System.Numerics;
using Serilog;

namespace Calculator;

public class Calculator<T> : ICalculator<T> where T : INumber<T>
{
    public T Add(T a, T b)
    {
        Log.Debug("Adding {First} + {Second} for {Type}", a, b, typeof(T).Name);
        return a + b;
    }

    public T Subtract(T a, T b)
    {
        Log.Information("Subtracting {First} - {Second} for {Type}", a, b, typeof(T).Name);
        return a - b;
    }

    public T Multiply(T a, T b)
    {
        Log.Information("Multiplying {First} * {Second} for {Type}", a, b, typeof(T).Name);
        return a * b;
    }

    public T Divide(T a, T b)
    {
        Log.Information("Dividing {First} / {Second} for {Type}", a, b, typeof(T).Name);
        return a / b;
    }
}