using Sqids;

namespace Person.v1
{
    public sealed record Person
    {
        public required int ID { get; init; }
        public required string FirstName { get; init; }
        public required string Surname { get; init; }
    }
}

namespace Person.v2
{
    public sealed record Person
    {
        public required int ID { get; init; }
        public string Identifier => new SqidsEncoder<int>().Encode(ID);
        public required string FirstName { get; init; }
        public required string Surname { get; init; }
    }
}

namespace Person.v3
{
    public sealed record Person
    {
        public required int ID { get; init; }
        public required string Identifier { get; init; }
        public required string FirstName { get; init; }
        public required string Surname { get; init; }
    }
}