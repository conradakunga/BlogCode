using System;

namespace DefaultInterface
{
    public class Mouse : IAnimal
    {
        public string Name => "Mouse";
        public void MakeSound() => Console.WriteLine("Squeak");
        public void Introduce() => Console.WriteLine("Squeak! I am a mouse");
    }

}