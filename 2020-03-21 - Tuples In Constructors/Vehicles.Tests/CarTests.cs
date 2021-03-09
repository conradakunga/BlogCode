using FluentAssertions;
using Xunit;

namespace Vehicles.Tests
{
    public class CarTests
    {
        [Fact]
        public void CarIsCreatedCorrectly()
        {
            string make = "Bugatti";
            string model = "Veyron";
            string serial = "00000234234";
            int cc = 7993;

            var car = new Car(make, model, serial, cc);
            car.Make.Should().Be(make);
            car.Model.Should().Be(model);
            car.Serial.Should().Be(serial);
            car.CC.Should().Be(cc);
        }

    }
}
