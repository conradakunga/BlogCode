using System.Globalization;

var entries = new DateEntry[]
{
    new("2025/08/23 12:33:11", "Japan"),
    new("23/08/2025 12:33:11", "Kenya"),
    new("23.08.2025 12:33:11", "Germany"),
    new("8/23/2025 12:33:11 PM", "USA"),
};


foreach (var country in entries)
{
    Console.WriteLine($"Setting the locale for {country.Country}");
    Thread.CurrentThread.CurrentCulture = GetCultureInfo(country.Country);
    foreach (var entry in entries)
    {
        if (DateTime.TryParse(entry.DateTime, GetCultureInfo(entry.Country), out var date))
        {
            // Parsing was successful
            Console.WriteLine($"Successfully parsed Date {entry.DateTime} for Country {entry.Country}: {date}");
        }
        else
        {
            // Parsing failed
            Console.WriteLine($"Failed to parse Date {entry.DateTime}");
        }
    }

    Console.WriteLine();
}

return;

CultureInfo GetCultureInfo(string country)
{
    return country switch
    {
        "Japan" => new CultureInfo("ja-JP"),
        "Kenya" => new CultureInfo("en-KE"),
        "Germany" => new CultureInfo("de-DE"),
        "USA" => new CultureInfo("en-US"),
        // Default if unrecognizable
        _ => CultureInfo.InvariantCulture
    };
}

internal record DateEntry(string DateTime, string Country);