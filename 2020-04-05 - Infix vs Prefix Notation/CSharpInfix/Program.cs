using System;
using System.Linq;

namespace CSharpInfix
{
    class Program
    {
        static void Main(string[] args)
        {
            // Two arguments
            Console.WriteLine(5 + 10);

            // Three arguments
            Console.WriteLine(5 + 10 + 15);

            // Using LINQ to sum the arguments explicity
            var arguments = new int[] { 5, 10, 15 };
            Console.WriteLine(arguments.Aggregate((x, y) => x + y));
        }
    }

}
