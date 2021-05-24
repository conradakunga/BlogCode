using System;

namespace DefaultInterface
{
    public class Cat : IAnimal
    {
        public string Name => "Cat";
        public void MakeSound() => Console.WriteLine("Meow");
    }
}