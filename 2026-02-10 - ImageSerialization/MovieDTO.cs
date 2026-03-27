namespace ImageSerialization;

public sealed record MovieDTO
{
    public required string Title { get; init; }
    public required int Length { get; init; }
    public required DateOnly ReleaseDate { get; init; }
    public required byte[] PosterData { get; init; } = [];
}