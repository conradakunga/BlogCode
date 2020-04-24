using System;
using FluentAssertions;
using Vehicles;
using Xunit;

namespace Vehicles.Tests
{

    public class MotorCycleTests
    {
        [Fact]
        public void MotorCycleIsCreatedCorrectly()
        {
            string make = "KTM";
            string model = "Duke";
            string serial = "00000234232344";
            int cc = 1301;

            var bike = new MotorCycle(make, model, serial, cc);
            bike.Make.Should().Be(make);
            bike.Model.Should().Be(model);
            bike.Serial.Should().Be(serial);
            bike.CC.Should().Be(cc);
        }
    }
}