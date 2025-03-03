namespace V1
{
    public sealed class DateInfo
    {
        public string Name { get; } = null!;
        public DateTime DateAndTime { get; }
    }
}

namespace V2
{
    public sealed class DateInfo
    {
        public string Name { get; } = null!;
        public DateOnly Date { get; }
    }
}

namespace V3
{
    public sealed class DateInfo
    {
        public string Name { get; } = null!;
        public DateTime DateAndTime { get; }
        public DateOnly Date => DateOnly.FromDateTime(DateAndTime);
    }
}

namespace V4
{
    public sealed class DateInfo
    {
        public string Name { get; } = null!;
        public TimeOnly Time { get; }
    }
}