using System.Numerics;

namespace Calculator;

public interface ICalculator<T> where T : INumber<T>
{
    T Add(T a, T b);
    T Subtract(T a, T b);
    T Multiply(T a, T b);
    T Divide(T a, T b);
}