using System;
using Vehicles;

namespace Vehicles.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var bike = new MotorCycle("Kawasaki", "Ninja", "234234", 400);
            var details = bike.GetMakeAndModel();
            Console.WriteLine($"The make is {details.Make} and the model is {details.Model}");
        }
    }
}
