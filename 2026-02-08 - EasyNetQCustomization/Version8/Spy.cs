using EasyNetQ;

[Queue("SpyQueue")]
public sealed record Spy(string FirstName, string OtherNames);