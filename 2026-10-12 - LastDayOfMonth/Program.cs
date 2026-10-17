var year = 2026;
foreach (var date in GetDatesInYearV1(year))
{
    Console.WriteLine(date);
}

foreach (var date in GetDatesInYearV2(year))
{
    Console.WriteLine(date);
}

return;

IEnumerable<DateOnly> GetDatesInYearV1(int year)
{
    return Enumerable.Range(1, 12).Select(x => new DateOnly(year, x, DateTime.DaysInMonth(year, x)));
}

IEnumerable<DateOnly> GetDatesInYearV2(int year)
{
    var temp = new DateOnly(year, 1, 1);
    while (temp.Year == year)
    {
        yield return temp.AddMonths(1).AddDays(-1);
        temp = temp.AddMonths(1);
    }
}