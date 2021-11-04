var names = new string[] { "Bartholomew", "Matthew", "Simon", "Jude" };

// Here the compiler will complain about a possible null
string notNullName = names.FirstOrDefault(n => n.Length > 20, "");

// This will have no problem
string? possibleNullName = names.FirstOrDefault(n => n.Length > 20);

Console.WriteLine(notNullName);

Console.WriteLine(possibleNullName);
