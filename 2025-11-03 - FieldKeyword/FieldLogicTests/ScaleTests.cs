using AwesomeAssertions;
using FieldLogic.V3;

namespace FieldLogicTests;

public class ScaleTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(0)]
    [InlineData(100)]
    public void Scale_Initializes_Correctly(int temperature)
    {
        var scale = new Scale()
        {
            Temperature = temperature
        };
        scale.Temperature.Should().Be(temperature);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-10)]
    public void Scale_Throws_Exception_With_Invalid_Value(int temperature)
    {
        var ex = Record.Exception(() =>
        {
            var scale = new Scale()
            {
                Temperature = temperature
            };
        });
        ex.Should().BeOfType<ArgumentOutOfRangeException>();
    }
}