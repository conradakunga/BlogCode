using System.Numerics;

namespace Calculator.V1
{
    public interface ICalculator
    {
        // Integer operations
        int Add(int a, int b);
        int Subtract(int a, int b);
        int Divide(int a, int b);
        int Multiply(int a, int b);

        // Decimal operations
        decimal Add(decimal a, decimal b);
        decimal Subtract(decimal a, decimal b);
        decimal Divide(decimal a, decimal b);
        decimal Multiply(decimal a, decimal b);
    }
}

namespace Calculator.V2
{
    public interface ICalculator<T> where T : INumber<T>
    {
        T Add(T a, T b);
        T Subtract(T a, T b);
        T Divide(T a, T b);
        T Multiply(T a, T b);
    }
}