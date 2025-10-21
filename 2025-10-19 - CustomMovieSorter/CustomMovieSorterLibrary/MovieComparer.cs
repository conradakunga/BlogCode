using System.Globalization;
using V1;

namespace CustomMovieSorterLibrary
{
    public sealed class MovieComparer : IComparer<Movie>, IEqualityComparer<Movie>
    {
        // Define the articles to ignore in the sort
        private static readonly string[] Articles = ["a ", "an ", "the "];

        // Create a CompareInfo object for comparison
        private static readonly CompareInfo CompareInfo = CultureInfo.InvariantCulture.CompareInfo;

        // Static instance creator
        public static readonly MovieComparer Instance = new();

        // Sanitize our input strings
        private static string Normalize(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            var trimmed = input.TrimStart();

            foreach (var article in Articles)
            {
                if (trimmed.StartsWith(article, StringComparison.InvariantCultureIgnoreCase))
                    return trimmed.Substring(article.Length).TrimStart();
            }

            return trimmed;
        }

        // Do the comparison
        public int Compare(Movie? x, Movie? y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (x is null) return -1;
            if (y is null) return 1;

            return CompareInfo.Compare(Normalize(x.Title), Normalize(y.Title), CompareOptions.IgnoreCase);
        }

        // Equality override
        public bool Equals(Movie? x, Movie? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;

            return string.Equals(Normalize(x.Title), Normalize(y.Title), StringComparison.InvariantCultureIgnoreCase);
        }

        // Hashcode override
        public int GetHashCode(Movie? obj)
        {
            if (obj?.Title is null)
                return 0;

            return StringComparer.InvariantCultureIgnoreCase.GetHashCode(Normalize(obj.Title));
        }
    }
}