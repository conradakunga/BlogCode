// byte
var randomByte = (byte)Random.Shared.Next(byte.MinValue, byte.MaxValue);
Console.WriteLine(randomByte);

// Singed byte
var randomsByte = (sbyte)Random.Shared.Next(sbyte.MinValue, sbyte.MaxValue + 1);
Console.WriteLine(randomsByte);

// Short
var randomShort = (short)Random.Shared.Next(short.MinValue, short.MaxValue + 1);
Console.WriteLine(randomShort);

// Unsinged short
var randomuShort = (ushort)Random.Shared.Next(ushort.MinValue, ushort.MaxValue + 1);

Console.WriteLine(randomuShort);