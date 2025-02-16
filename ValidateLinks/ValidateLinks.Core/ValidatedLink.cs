namespace ValidateLinks.Core;

public sealed record ValidatedLink
{
    public required string Url { get; init; }
    public required TimeOnly StartTime { get; init; }
    public required TimeOnly EndTime { get; init; }
    public required string Error { get; init; }
    public bool Success => string.IsNullOrEmpty(Error);
}