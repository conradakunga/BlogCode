using NUnit.Framework;

namespace NUnitTests
{
    public class NUnitTests
    {
        [Test]
        public void Test_For_Sum()
        {
            var sum = 2 + 5;
            Assert.AreEqual(sum, 7);
        }
    }
}