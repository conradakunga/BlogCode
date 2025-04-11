using System.Numerics;

namespace Calculator;

public class Calculator<T> : ICalculator<T> where T : INumber<T>
{
    public T Add(T a, T b)
    {
        return a + b;
    }

    public T Subtract(T a, T b)
    {
        return a - b;
    }

    public T Multiply(T a, T b)
    {
        return a * b;
    }

    public T Divide(T a, T b)
    {
        return a / b;
    }
}