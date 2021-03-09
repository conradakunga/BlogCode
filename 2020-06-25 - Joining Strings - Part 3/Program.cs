using System;
using System.Text;

namespace Stringbuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new, empty StringBuilder 
            var simpsons = new StringBuilder();
            simpsons.Append("Marge");
            simpsons.Append("Homer");
            simpsons.Append("Bart");
            simpsons.Append("Lisa");

            //Write string to console
            Console.WriteLine(simpsons);

            // Create a StringBuilder that is initialized
            var griffins = new StringBuilder("Peter");
            griffins.Append("Lois");
            griffins.Append("Meg");
            griffins.Append("Chris");
            griffins.Append("Stewie");

            // Write string to console
            Console.WriteLine(griffins);

            var holidays = new StringBuilder();
            holidays.AppendFormat("New Year's Day {0:d MMM yyyy}", new DateTime(2020, 1, 1));
            holidays.Append($"Christmas { new DateTime(2020, 12, 25):d MMM yyyy}");
            Console.WriteLine(holidays);

            var newHolidays = new StringBuilder();
            newHolidays.AppendLine($"Labour Day { new DateTime(2020, 5, 1):d MMM yyyy}");
            newHolidays.AppendLine($"Boxing Day { new DateTime(2020, 12, 26):d MMM yyyy}");
            Console.WriteLine(newHolidays);

            newHolidays[6] = '-';

            Console.WriteLine(newHolidays);

            newHolidays.Insert(0, $"Valentines' Day {new DateTime(2020, 2, 14):d MMM yyyy}{Environment.NewLine}");

            Console.WriteLine(newHolidays);

        }
    }
}
