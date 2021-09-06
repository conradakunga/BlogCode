using System.Globalization;

// Vanilla DateOnly
var newDate = new DateOnly(2022, 1, 1);

// DateOnly from DateTIme
var otherNewDate = DateOnly.FromDateTime(DateTime.Now);

// Dateonly from daynumber

var dayZero = DateOnly.FromDayNumber(0);

// Parsing dates
var christmas = DateOnly.ParseExact("2021-12-25", "yyyy-MM-dd");

// Manipulating dateonly
var nextYear = newDate.AddYears(1);
var lastYear = newDate.AddYears(-1);

// Create using a different calendar

var persianCalendar = new PersianCalendar();
var persianCurrentDate = new DateOnly(2021, 1, 1, persianCalendar);
Console.WriteLine(persianCurrentDate);
