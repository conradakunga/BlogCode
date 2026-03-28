namespace ComputeDontStore.v1
{
    public record OrderEntry
    {
        public required string Name { get; init; }
        public required int Quantity { get; init; }
        public required decimal Price { get; init; }
        public required decimal TaxRate { get; init; }
        public required decimal GrossAmount { get; init; }
        public required decimal Taxes { get; init; }
        public required decimal NetAmount { get; init; }
    }
}

namespace ComputeDontStore.v2
{
    public record OrderEntry
    {
        public required string Name { get; init; }
        public required int Quantity { get; init; }
        public required decimal Price { get; init; }
        public required decimal TaxRate { get; init; }
        public decimal GrossAmount => Quantity * Price;
        public decimal Taxes => GrossAmount * TaxRate;
        public decimal NetAmount => GrossAmount - Taxes;
    }
}