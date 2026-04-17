namespace v1
{
    public sealed record CarDTO
    {
        public required int Id { get; set; }
        public required string Make { get; set; }
        public required string Model { get; set; }
        public required int Capacity { get; set; }
        public required int YearOfManufacture { get; set; }
    }
}

namespace v2
{
    public sealed record CarDTO
    {
        public required int Id { get; init; }
        public required string Make { get; init; }
        public required string Model { get; init; }
        public required int Capacity { get; init; }
        public required int YearOfManufacture { get; init; }
    }
}