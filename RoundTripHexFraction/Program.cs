using System.Globalization;

var natruralLog = Math.E;

var hexValue = natruralLog.ToString("x");

var number = double.Parse(hexValue, NumberStyles.HexFloat);

// Print number
Console.WriteLine(number);

// Verify parity
Console.WriteLine(number == natruralLog);