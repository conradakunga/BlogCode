namespace V1
{
    public sealed record Agent
    {
        public required string FirstName { get; set; }
        public required string Surname { get; set; }
    }
}

namespace V2
{
    public sealed record Agent
    {
        public required string FirstName { get; init; }
        public required string Surname { get; init; }
    }
}

namespace V3
{
    public sealed record Agent
    {
        public Agent(string firstName, string surname)
        {
            FirstName = firstName;
            Surname = surname;
        }

        public string FirstName { get; }
        public string Surname { get; }
    }
}