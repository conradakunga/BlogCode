// Create the spy asynchronously
var jamesBond = await v2.Spy.CreateSpy("James", "Bond");
// Use the spy
Console.WriteLine($"Spy was created: {jamesBond.FirstName} {jamesBond.Surname}");