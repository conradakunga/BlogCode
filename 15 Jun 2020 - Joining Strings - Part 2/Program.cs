using System;
using System.Collections.Generic;

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

            var list = new List<string>();

            list.Add(son);
            list.Add(daughter);
            list.Add(mother);
            list.Add(clown);

            var characters = String.Concat(list);

            Console.WriteLine(characters);

        }
    }
}