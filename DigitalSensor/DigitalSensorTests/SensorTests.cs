using AwesomeAssertions;
using V4;

namespace DigitalSensorTests;

public class SensorTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(-1, 0)]
    [InlineData(5, 5)]
    [InlineData(10, 10)]
    [InlineData(11, 10)]
    public void Test1(int input, int expected)
    {
        var sensor = new Sensor(input);
        sensor.Display.Should().Be(expected);
    }
}