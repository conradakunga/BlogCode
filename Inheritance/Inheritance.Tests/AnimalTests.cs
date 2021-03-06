using FluentAssertions;
using Xunit;

namespace Inheritance.Tests
{
    public class AnimalTests
    {
        [Fact]
        public void A_Collection_Of_Animals_Is_Processed_Correctly()
        {
            var animals = new Animal[] {
                new Dog(),
                new Duck(),
                new Snake()
            };

            foreach (var animal in animals)
            {
                var sound = animal.MakeSound();
                sound.Should().NotBeEmpty();
                sound.Should().NotBe("Noise");
            }
        }
    }
}
