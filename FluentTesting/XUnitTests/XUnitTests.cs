using System;
using FluentAssertions;
using Xunit;

namespace XUnitTests
{
    public class XUnitTests
    {
        [Fact]
        public void Test_For_Sum()
        {
            var sum = 2 + 5;
            Assert.Equal(7, sum);
        }
        [Fact]
        public void Test_For_Sum2()
        {
            var sum = 2 + 5;
            sum.Should().Be(7);
        }
        [Fact]
        public void Test_For_Sum3()
        {
            var sum = 2 + 5;
            sum.Should().Be(7).And.BeGreaterThan(0);
        }
        [Fact]
        public void Test_For_Exception()
        {
            int denom = 0;
            var result = 0;
            Assert.Throws<DivideByZeroException>(() => result = 6 / denom);
        }
        [Fact]
        public void Test_For_Exception2()
        {
            int denom = 0;
            var result = 0;
            // Create an action
            Action action = () => result = 6 / denom;
            // Attemt to execute the action
            action.Should().Throw<DivideByZeroException>()
                .WithMessage("Attempted to divide by zero.");

        }
    }
}
