// .NET 10	

{
    Type nullableIntType = typeof(int?);
    Console.WriteLine(nullableIntType.Name);
    Type? underlying = Nullable.GetUnderlyingType(nullableIntType);
    Console.WriteLine(underlying.Name);
}

// .NET 11

{
    Type nullableIntType = typeof(int?);
    Type? underlying = nullableIntType.GetNullableUnderlyingType();
    Console.WriteLine(underlying.Name);
}