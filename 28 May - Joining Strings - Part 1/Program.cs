using System;

namespace concatenation
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstName = "Homer";
            var surname = "Simpson";
            var fullName = firstName + " " + surname;
            Console.WriteLine(fullName);


            var title = "His Excellency";
            var initial = "J";
            fullName = title + " " + firstName + " " + initial + " " + surname;
            Console.WriteLine(fullName);

            var children = "Bart" + " " + "Lisa" + "Maggie";
            Console.WriteLine(children);
        }
    }
}
