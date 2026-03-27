using SixLabors.ImageSharp;

namespace ImageSerialization;

public sealed record Movie
{
    public required string Title { get; init; }
    public required int Length { get; init; }
    public required DateOnly ReleaseDate { get; init; }
    public required Image Poster { get; init; }
}