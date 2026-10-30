using System.Globalization;

//
// Change the format info locally
//

// Clone the existing culture and extract the DateTimeFormatInfo
var dateTimeFormatInfo = (DateTimeFormatInfo)
    CultureInfo.InvariantCulture.DateTimeFormat.Clone();

// Modify what we want to change - the date separator
dateTimeFormatInfo.DateSeparator = "+";

// Now, when formatting, specify our format

Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy", dateTimeFormatInfo));

Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));

//
// Change the culture globally
//

// Clone the current culture, to use as a base
var culture = CultureInfo.InvariantCulture.Clone() as CultureInfo;

// Modify what we want to change - the date separator
culture!.DateTimeFormat.DateSeparator = "+";

// Set the thread's culture to our new culture
Thread.CurrentThread.CurrentCulture = culture;

// Work as normal
Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));