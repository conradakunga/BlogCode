using System.Globalization;

// Fetch all the cultures supported
var allCultures = CultureInfo.GetCultures(CultureTypes.AllCultures)
    .Select(x => new { x.Name, x.NativeName, x.DisplayName }).ToArray();

// Print count
Console.WriteLine($"There are {allCultures.Length} Locales");

// List all the found cultures
foreach (var culture in allCultures)
{
    Console.WriteLine(
        $"Name : {culture.Name};\tNative Name {culture.NativeName};\tDisplay Name: {culture.DisplayName}");
}

var kenyanCultures = allCultures.Where(x => x.Name.Contains("-KE")).ToArray();
// Print count
Console.WriteLine($"There are {kenyanCultures.Length} Locales");

// List all the found cultures
foreach (var culture in kenyanCultures)
{
    Console.WriteLine(
        $"Name : {culture.Name};\tNative Name {culture.NativeName};\tDisplay Name: {culture.DisplayName}");
}

foreach (var cultureInfo in kenyanCultures)
{
    // Load the culture by name
    var culture = new CultureInfo(cultureInfo.Name);
    // Fetch format info
    var format = culture.DateTimeFormat;
    // Get the days of the week
    var daysOfTheWeek = format.DayNames;
    // Get the months of the year
    var monthsOfTheYear = format.MonthGenitiveNames;
    // Print
    Console.WriteLine(cultureInfo.DisplayName);
    var days = string.Join(",", daysOfTheWeek);
    Console.WriteLine($"Days Of The Week: {days}");
    var months = string.Join(",", monthsOfTheYear);
    Console.WriteLine($"Months Of The Year: {months}");
    Console.WriteLine();
}

// Output days of the week in markdown
Console.WriteLine("| Language | Sunday | Monday | Tuesday | Wednesday | Thursday | Friday | Saturday |");
Console.WriteLine("| ------ | ------ | ------ | ------- | --------- | -------- | ------ | -------- |");
foreach (var cultureInfo in kenyanCultures)
{
    var culture = new CultureInfo(cultureInfo.Name);
    var format = culture.DateTimeFormat;
    var daysOfTheWeek = format.DayNames;
    Console.Write($"| {culture.DisplayName} ");
    for (var i = 0; i < 7; i++)
    {
        Console.Write($"| {daysOfTheWeek[i]}");
    }

    Console.Write(" |");
    Console.WriteLine();
}

// Output months of the year in markdown
Console.WriteLine(
    "| Language | January| February| March| April| May| June| July| August| September| October| November| December |");
Console.WriteLine(
    "| ------ | ------ | ------ | ------- | --------- | -------- | ------ | -------- | -------- | -------- | -------- | -------- |-------- |");
foreach (var cultureInfo in kenyanCultures)
{
    var culture = new CultureInfo(cultureInfo.Name);
    var format = culture.DateTimeFormat;
    var monthsOfTheYear = format.MonthGenitiveNames;
    Console.Write($"| {culture.DisplayName} ");
    for (var i = 0; i < 12; i++)
    {
        Console.Write($"| {monthsOfTheYear[i]}");
    }

    Console.Write(" |");
    Console.WriteLine();
}