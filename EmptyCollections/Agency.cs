namespace v1
{
    public sealed class Agency
    {
        public required string Name { get; init; }
        public required Spy[] Spies { get; init; }
    }
}

namespace v2
{
    public sealed class Agency
    {
        public string Name { get; set; }
        public Spy[] Spies { get; set; } = [];
    }
}