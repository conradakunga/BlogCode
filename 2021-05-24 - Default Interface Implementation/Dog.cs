using System;

namespace DefaultInterface
{
    public class Dog : IAnimal
    {
        public string Name => "Dog";
        public void MakeSound() => Console.WriteLine("Woof");
    }
}