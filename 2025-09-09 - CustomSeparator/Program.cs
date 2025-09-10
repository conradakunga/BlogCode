using System.Globalization;

string[] cultureStrings =
[
    "ar-EG", "hy-AM", "az-AZ", "be-BY", "bg-BG", "hr-HR", "cs-CZ", "da-DK", "nl-NL", "fi-FI", "fr-CA", "fr-FR", "ka-GE",
    "de-DE", "el-GR", "hu-HU", "id-ID", "it-IT", "kk-KZ", "lv-LV", "lt-LT", "nb-NO", "pl-PL", "pt-BR", "pt-PT", "ro-RO",
    "ru-RU", "sr-RS", "sk-SK", "sl-SI", "es-AR", "es-BO", "es-CL", "es-CO", "es-EC", "es-PY", "es-ES", "es-UY", "es-VE",
    "sv-SE", "tr-TR", "uk-UA", "vi-VN"
];
// Build a collection of locales
var locales = cultureStrings.Select(s => new CultureInfo(s)).OrderBy(s => s.EnglishName).ToArray();
// Print sample values
foreach (var locale in locales)
{
    Console.WriteLine($"{locale.EnglishName} - ({locale.Name})");
    Console.WriteLine(string.Format(locale, "{0:#,0.00}", 10_000));
}

//
// Modify an existing locale
// 

Console.WriteLine();
Console.WriteLine("--Modify existing locale--");
Console.WriteLine();

var existingLocale = new CultureInfo("en-KE")
{
    NumberFormat =
    {
        NumberDecimalSeparator = ",",
        NumberGroupSeparator = " "
    }
};
Console.WriteLine(string.Format(existingLocale, "{0:#,0.00}", 10_000));

// 
// Create a number format
//

Console.WriteLine();
Console.WriteLine("--Create a number format--");
Console.WriteLine();

var nf = new NumberFormatInfo
{
    NumberDecimalSeparator = ",",
    NumberGroupSeparator = " "
};

Console.WriteLine(string.Format(nf, "{0:#,0.00}", 10_000));

Thread.CurrentThread.CurrentCulture = existingLocale;
Console.WriteLine("{0:#,0.00}", 10_000);