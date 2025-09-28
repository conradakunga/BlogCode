var randomuInt = (uint)Random.Shared.NextInt64(uint.MinValue, ((long)uint.MaxValue) + 1);
Console.WriteLine(randomuInt);