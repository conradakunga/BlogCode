namespace v1
{
    public sealed class CarDTO
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
    public sealed class CarDTO : IEquatable<CarDTO>
    {
        public required int Id { get; set; }
        public required string Make { get; set; }
        public required string Model { get; set; }
        public required int Capacity { get; set; }
        public required int YearOfManufacture { get; set; }

        public bool Equals(CarDTO? other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Id == other.Id &&
                   Make == other.Make &&
                   Model == other.Model &&
                   Capacity == other.Capacity &&
                   YearOfManufacture == other.YearOfManufacture;
        }

        public override bool Equals(object? obj)
            => Equals(obj as CarDTO);

        public override int GetHashCode()
            => HashCode.Combine(Id, Make, Model, Capacity, YearOfManufacture);

        public static bool operator ==(CarDTO? left, CarDTO? right)
        {
            if (left is null)
                return right is null;

            return left.Equals(right);
        }

        public static bool operator !=(CarDTO? left, CarDTO? right)
            => !(left == right);
    }
}

namespace v3
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