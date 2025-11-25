using System.Globalization;

string[] cultures = ["en-US", "en-GB", "fr-FR", "es-ES"];
foreach (var culture in cultures)
{
    Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
    const string parseFormat = "d/M/yyyy";
    var dateString = "2/1/2025";
    if (DateTime.TryParseExact(dateString, parseFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
            out DateTime date))
    {
        Console.WriteLine($"{culture} - {date:d MMM yyyy}");
    }
    else
    {
        Console.WriteLine($"Could not parse {dateString} in the format {parseFormat}");
    }
}