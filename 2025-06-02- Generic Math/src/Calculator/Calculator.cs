using System.Numerics;

namespace Calculator.V1
{
    public sealed class Calculator : ICalculator
    {
        // Integer operations
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Divide(int a, int b)
        {
            return a / b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        // Decimal operations
        public decimal Add(decimal a, decimal b)
        {
            return a + b;
        }


        public decimal Subtract(decimal a, decimal b)
        {
            return a - b;
        }


        public decimal Divide(decimal a, decimal b)
        {
            return a / b;
        }


        public decimal Multiply(decimal a, decimal b)
        {
            return a * b;
        }
    }
}

namespace Calculator.V2
{
    public sealed class Calculator<T> : ICalculator<T> where T : INumber<T>
    {
        public T Add(T a, T b)
        {
            return a + b;
        }

        public T Subtract(T a, T b)
        {
            return a - b;
        }

        public T Divide(T a, T b)
        {
            return a / b;
        }

        public T Multiply(T a, T b)
        {
            return a * b;
        }
    }
}