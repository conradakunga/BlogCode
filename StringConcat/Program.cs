using System;

namespace StringConcat
{
    class Program
    {
        static void Main(string[] args)
        {
            var son = String.Concat("Bart", "Simpson");

            Console.WriteLine(son);

            var daughter = String.Concat("Lisa", "Marie", "Simpson");

            Console.WriteLine(daughter);

            var mother = String.Concat("Marjorie", "Jacqueline", "Bouvier", "Simpson");

            Console.WriteLine(mother);

            var clown = String.Concat("Herschel", "Shmoikel", "Pinchas", "Yerucham", "Krustofsky");

            Console.WriteLine(clown);
        }
    }
}