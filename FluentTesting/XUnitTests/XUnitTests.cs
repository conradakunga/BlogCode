using System;
using Xunit;

namespace XUnitTests
{
    public class XUnitTests
    {
        [Fact]
        public void Test_For_Sum()
        {
            var sum = 2 + 5;
            Assert.Equal(sum, 7);
        }
    }
}
