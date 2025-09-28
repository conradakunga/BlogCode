using System.Security.Cryptography;

// Create a single random byte buffer
Span<byte> buffer = stackalloc byte[1];
// Fill buffer with the random number generator
RandomNumberGenerator.Fill(buffer);
// Use the lowest bit to determine true or false
var randomBoolean = (buffer[0] & 1) == 1;

// Output
Console.WriteLine(randomBoolean);