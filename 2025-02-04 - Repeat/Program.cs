//
// Generate 100 instances of James Bond
//

// First create an enumerable of 100 numbers

var jamesBonds = Enumerable.Range(0, 100)
    // Project into an Agent object, but since we're not using the numbers, 
    // Discard them using the discard _
    .Select(_ => new Agent { Name = "James Bond", DateOfBirth = new DateOnly(1970, 1, 1) }).ToList();

// Print to console
jamesBonds.ForEach(agent => Console.WriteLine($"{agent.Name}, born on {agent.DateOfBirth}"));


jamesBonds = Enumerable.Repeat(new Agent { Name = "James Bond", DateOfBirth = new DateOnly(1970, 1, 1) }, 100)
    .ToList();
// Print to console
jamesBonds.ForEach(agent => Console.WriteLine($"{agent.Name}, born on {agent.DateOfBirth}"));