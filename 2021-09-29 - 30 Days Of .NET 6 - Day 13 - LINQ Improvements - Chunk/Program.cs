var range = Enumerable.Range(0, 50).ToArray();

// Partition the range into chunks of 10
var chunks = range.Chunk(size: 10).ToList();

// Loop though each chunk and process
for (var i = 0; i < chunks.Count(); i++)
{
    Console.WriteLine($"Processing chunk {i}");
    Print(chunks[i]);
    // Call our expensive service and pass the partition
    // CallExpensiveService(chunks[i]);
}

void Print(int[] input) => Console.WriteLine(string.Join(",", input));