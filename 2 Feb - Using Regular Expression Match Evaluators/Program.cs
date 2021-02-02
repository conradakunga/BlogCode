using System;
using System.Text.RegularExpressions;

namespace RegexMatchEvaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"(?<temperature>\d+)\s?(?<notation>(°|degrees))\s?C");
            var sourceText = @"Water boils at 100°C at sea level.

It freezes at 0°C, also at sea level.

A human body is normally 37 degrees C.

Death can occur if the body temperature drops below 35 degrees C.

Zero degrees C is 35° F";

            var targetText = regex.Replace(sourceText, new MatchEvaluator(ConvertToFahrenheit));
            Console.WriteLine(targetText);
        }
        static string ConvertToFahrenheit(Match match)
        {
            // Get the temperature string, and convert
            var celsius = Convert.ToDecimal(match.Groups["temperature"].Value);
            // Get the original notation used
            var notation = match.Groups["notation"].Value;
            // Convert the temperature
            var fahrenheit = ((9M / 5M) * celsius) + 32M;
            // Return the new string
            return $"{fahrenheit} {notation} F";
        }
    }
}
