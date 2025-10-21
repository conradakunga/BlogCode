using AwesomeAssertions;
using CustomMovieSorterLibrary;
using V1;

namespace CustomMovieSorterTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        string[] movieTitles = ["Avatar", "The Awakening", "A Tale Of Two Cities", "The Aviator", "Beowulf"];
        var movies = movieTitles.Select(x => new Movie
        {
            Title = x,
            Year = 1990
        }).ToList();

        movies.Sort(new MovieComparer());

        movies[0].Title.Should().Be("Avatar");
        movies[1].Title.Should().Be("The Aviator");
        movies[2].Title.Should().Be("The Awakening");
        movies[3].Title.Should().Be("Beowulf");
        movies[4].Title.Should().Be("A Tale Of Two Cities");

        var orderedMovies = movies.OrderBy(x => x).ToList();
        orderedMovies[0].Title.Should().Be("Avatar");
        orderedMovies[1].Title.Should().Be("The Aviator");
        orderedMovies[2].Title.Should().Be("The Awakening");
        orderedMovies[3].Title.Should().Be("Beowulf");
        orderedMovies[4].Title.Should().Be("A Tale Of Two Cities");
    }
}