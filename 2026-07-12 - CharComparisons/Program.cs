Console.WriteLine('i'.Equals('I', StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine('i'.Equals('I', StringComparison.CurrentCulture));
Console.WriteLine('i'.Equals('I', StringComparison.InvariantCulture));
Console.WriteLine('i'.Equals('I', StringComparison.InvariantCultureIgnoreCase));
Console.WriteLine('i'.Equals('I', StringComparison.Ordinal));
Console.WriteLine('i'.Equals('I', StringComparison.OrdinalIgnoreCase));


Console.WriteLine('i'.Equals('I'));

Console.WriteLine(string.Equals('i'.ToString(), 'I'.ToString(), StringComparison.CurrentCultureIgnoreCase));