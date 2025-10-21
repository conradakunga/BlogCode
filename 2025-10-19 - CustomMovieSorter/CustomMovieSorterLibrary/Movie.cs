using CustomMovieSorterLibrary;

namespace V1
{
    public sealed record Movie : IComparable<Movie>
    {
        public required string Title { get; init; }
        public required short Year { get; init; }

        // Delegate to comparer
        public int CompareTo(Movie? other) => MovieComparer.Instance.Compare(this, other);

        // Delegate to comparer
        public override int GetHashCode() => MovieComparer.Instance.GetHashCode(this);
    }
}

namespace V2
{
    public sealed record Movie
    {
        public required string Title { get; set; }

        // Remove the prefix "The" if it exists
        public string SortTitle => Title.StartsWith("The") ? Title.Remove(0, 4) : Title;
        public required short Year { get; set; }
    }
}