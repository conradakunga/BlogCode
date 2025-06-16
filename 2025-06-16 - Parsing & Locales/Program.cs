// Japan

using System.Globalization;

Thread.CurrentThread.CurrentCulture = new CultureInfo("ja-JP");
Console.WriteLine(DateTime.Now);
// Kenya (English)
Thread.CurrentThread.CurrentCulture = new CultureInfo("en-KE");
Console.WriteLine(DateTime.Now);
// German
Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
Console.WriteLine(DateTime.Now);
// USA (English)
Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
Console.WriteLine(DateTime.Now);

// Change locale then parse

var japanDate = "2025/06/16 21:32:29";
Thread.CurrentThread.CurrentCulture = new CultureInfo("ja-JP");
_ = DateTime.Parse(japanDate);
var kenyaDate = "16/06/2025 21:32:29";
Thread.CurrentThread.CurrentCulture = new CultureInfo("en-KE");
_ = DateTime.Parse(kenyaDate);
var germanyDate = "16.06.2025 21:32:29";
Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
_ = DateTime.Parse(germanyDate);
var usaDate = "6/16/2025 9:32:29 PM";
Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
_ = DateTime.Parse(usaDate);

// Provide locale during parsing

japanDate = "2025/06/16 21:32:29";
_ = DateTime.Parse(japanDate, new CultureInfo("ja-JP"));
kenyaDate = "16/06/2025 21:32:29";
Thread.CurrentThread.CurrentCulture = new CultureInfo("en-KE");
_ = DateTime.Parse(kenyaDate, new CultureInfo("en-KE"));
germanyDate = "16.06.2025 21:32:29";
_ = DateTime.Parse(germanyDate, new CultureInfo("de-DE"));
usaDate = "6/16/2025 9:32:29 PM";
_ = DateTime.Parse(usaDate, new CultureInfo("en-US"));

// Parse with exact format

japanDate = "2025/06/16 21:32:29";
_ = DateTime.ParseExact(japanDate, "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);
kenyaDate = "16/06/2025 21:32:29";
_ = DateTime.ParseExact(kenyaDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);
germanyDate = "16.06.2025 21:32:29";
_ = DateTime.ParseExact(germanyDate, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);
usaDate = "6/16/2025 9:32:29 PM";
_ = DateTime.ParseExact(usaDate, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None);