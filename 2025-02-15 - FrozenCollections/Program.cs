using System.Collections.Frozen;

string[] spies = ["James Bond", "James Bond", "Eve MoneyPenny", "Evelyn Salt"];

// Print to console
foreach (string spy in spies)
    Console.WriteLine(spy);

Console.WriteLine();

// Modify the first element
spies[0] = "Ethan Hunt";
foreach (string spy in spies)
    Console.WriteLine(spy);

//Get a read only collection
var readOnlySpies = spies.AsReadOnly();
foreach (string spy in readOnlySpies)
    Console.WriteLine(spy);

Console.WriteLine();

// readOnlySpies[0] = "Ethan Hunt";

// Modify the second element
spies[1] = "Roz Myers";
foreach (string spy in readOnlySpies)
    Console.WriteLine(spy);

var frozenSpies = spies.ToFrozenSet();
foreach (string spy in frozenSpies)
    Console.WriteLine(spy);

Console.WriteLine();

spies[1] = "Jason Bourne";
foreach (string spy in frozenSpies)
    Console.WriteLine(spy);