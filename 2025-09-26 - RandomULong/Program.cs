// Create a 64 bit array
var randomNumberBytes = new byte[8];
// Fill with random bytes
Random.Shared.NextBytes(randomNumberBytes);
// Convert to an unsinged int64 (long)
var randomNumber = BitConverter.ToUInt64(randomNumberBytes);
Console.WriteLine(randomNumber);