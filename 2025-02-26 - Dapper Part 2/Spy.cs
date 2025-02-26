namespace V1
{
    public sealed record Spy(int SpyID, string Name, DateTime DateOfBirth, decimal Height, bool Active);
}

namespace V2
{
    public sealed record Spy(int ID, string FullNames, DateTime BirthDate);
}

namespace V3
{
    public sealed record Spy
    {
        public required int ID { get; init; }
        public required string FullNames { get; init; }
        public required DateTime BirthDate { get; init; }
        // Compute the age against the current year
        public int Age => DateTime.Now.Year - BirthDate.Year;
    }
}