using AwesomeAssertions;

namespace TestsForSkipping;

public class EvenOddDetectionTests
{
    [Fact(Skip = "Do not run this before Christmas")]
    private void Odd_Detection_Works()
    {
        (3 % 2 != 0).Should().BeTrue();
    }

    [Fact]
    public void Even_Detection_Works()
    {
        (4 % 2 == 0).Should().BeTrue();
    }
}