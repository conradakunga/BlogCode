using System.Globalization;

string[] cultureCodes = ["en-GB", "en-US", "fr-FR", "de-DE", "en-KE", "en-AU"];

foreach (string code in cultureCodes)
{
    var culture = new CultureInfo(code);
    Console.WriteLine(new string('-', culture.Name.Length));
    Console.WriteLine(culture.EnglishName);
    Console.WriteLine(new string('-', culture.Name.Length));
    for (var i = 1; i <= 12; i++)
    {
        var date = new DateTime(2025, i, 1);
        Console.WriteLine(string.Format(culture, "{0:d MMM yyyy}", date));
    }
}