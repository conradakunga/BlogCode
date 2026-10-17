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
    return Enumerable.Range(1, 12).Select(x => new DateOnly(year, x, 1));
}

IEnumerable<DateOnly> GetDatesInYearV2(int year)
{
    var start = new DateOnly(year, 1, 1);
    var temp = start;
    while (temp.Year == year)
    {
        yield return temp;
        temp = temp.AddMonths(1);
    }
}