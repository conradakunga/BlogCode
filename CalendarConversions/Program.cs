//Create the date in the Julian Calendar	

using NodaTime;

var julianDate = new LocalDate(1582, 10, 5, CalendarSystem.Julian);
Console.WriteLine($"Julian: {julianDate}");

//Convert the date to the Gregorian calendar
var gregorianDate = julianDate.WithCalendar(CalendarSystem.Gregorian);
Console.WriteLine($"Gregorian: {gregorianDate}");