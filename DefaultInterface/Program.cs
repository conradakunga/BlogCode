using System;

namespace DefaultInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            var dog = new Dog();
            dog.MakeSound();
            ((IAnimal)dog).Introduce();

            IAnimal cat = new Cat();
            cat.MakeSound();
            cat.Introduce();

            var mouse = new Mouse();
            mouse.MakeSound();
            mouse.Introduce();
        }
    }
}
