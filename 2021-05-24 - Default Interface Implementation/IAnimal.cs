using System;

namespace DefaultInterface
{
    public interface IAnimal
    {
        string Name { get; }
        void MakeSound();
        void Introduce() => Console.WriteLine("Hello");
    }
}