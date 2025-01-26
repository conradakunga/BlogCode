public sealed record StockTransaction
{
    public required string Stock { get; init; }
    public required decimal Price { get; init; }
    public required int Quantity { get; init; }
}