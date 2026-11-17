namespace Base64UrlEncode;

public sealed class SearchRequest
{
    public required string SearchText { get; init; }
    public required string SortColumn { get; init; }
    public required int PageNumber { get; init; }
    public required int PageSize { get; init; }
    public required string Database { get; init; }
    public required bool ActiveOnly { get; init; }
}