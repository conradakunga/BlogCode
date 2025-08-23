using AwesomeAssertions;
using StringSorters;

namespace Tests;

public class StringComparerTests
{
    [Theory]
    [InlineData("Dos", "Dos", 0)]
    [InlineData("Dos", "DOS", 0)]
    [InlineData("Dos", "Windows", -19)]
    [InlineData("Windows 2", "Windows 10", -1)]
    [InlineData("Windows 1", "Windows 10", -1)]
    public void StringValueSortCorrectly(string left, string right, int expected)
    {
        var comparer = new MagnificentStringComparer();
        comparer.Compare(left, right).Should().Be(expected);
    }

    [Fact]
    public void Sorting_Functions_Correctly()
    {
        string[] raw =
        [
            "Windows 2000",
            "Windows 2",
            "Windows 1",
            "Windows 98",
            "Windows 4",
            "Windows 95",
            "Windows 5",
            "Windows 7",
            "Windows 8",
            "Windows 10",
            "Windows 3",
            "Windows 3.11",
            "Windows 3.1",
            "DOS 1",
            "DOS 3.1",
            "DOS 3.11",
            "DOS"
        ];

        string[] final =
        [
            "DOS",
            "DOS 1",
            "DOS 3.1",
            "DOS 3.11",
            "Windows 1",
            "Windows 2",
            "Windows 3",
            "Windows 3.1",
            "Windows 3.11",
            "Windows 4",
            "Windows 5",
            "Windows 7",
            "Windows 8",
            "Windows 10",
            "Windows 95",
            "Windows 98",
            "Windows 2000",
        ];

        var sortedStrings = raw.ToList();
        sortedStrings.Sort(new MagnificentStringComparer());
        sortedStrings.Should().Equal(final);
    }
}