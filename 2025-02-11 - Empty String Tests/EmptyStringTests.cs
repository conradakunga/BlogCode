using Shouldly;

namespace EmptyStringTests;

public class EmptyStringTests
{
    public static IEnumerable<object[]> SampleStrings()
    {
        yield return [null]; // a null
        yield return [""]; // a null string
        yield return [" "]; // a space
        yield return ["   "]; // a tab
        yield return [Environment.NewLine]; // a newline
    }

    [Theory]
    [MemberData(nameof(SampleStrings))]
    public void NullCheck(string sample)
    {
        (sample == null).ShouldBe(true);
    }


    [Theory]
    [MemberData(nameof(SampleStrings))]
    public void NullStringCheck(string sample)
    {
        (sample == "").ShouldBe(true);
    }

    [Theory]
    [MemberData(nameof(SampleStrings))]
    public void IsNullOrEmpty(string sample)
    {
        string.IsNullOrEmpty(sample).ShouldBe(true);
    }

    [Theory]
    [MemberData(nameof(SampleStrings))]
    public void IsNullOrWhiteSpace(string sample)
    {
        string.IsNullOrWhiteSpace(sample).ShouldBe(true);
    }

    [Theory]
    [MemberData(nameof(SampleStrings))]
    public void TrimCheck(string sample)
    {
        (sample?.Trim().Length == 0).ShouldBe(true);
    }
}