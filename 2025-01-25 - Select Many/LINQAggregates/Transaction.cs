public sealed record Transaction
{
    public required decimal Price { get; init; }
    public required int Quantity { get; init; }
}