using Mtf.HardwareKey.Services;

namespace Mtf.HardwareKey.UnitTests.Services
{
    [TestFixture]
    public class UInt32TransfomerTests
    {
        [TestCase(5, 5)]
        [TestCase(50, 50)]
        [TestCase(-1, 65535)]
        [TestCase(UInt16.MinValue, 0)]
        [TestCase(101, 105)]
        [TestCase(102, 110)]
        [TestCase(110, 170)]
        [TestCase(200, 2510)]
        [TestCase(830, 65465)]
        public void Test(int number, int expectedResult)
        {
            var actualResult = UInt32Transfomer.ToSziltechByte(number);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase(UInt16.MaxValue)]
        [TestCase(831)]
        public void TestException(int number)
        {
            Assert.Throws<OverflowException>(() => UInt32Transfomer.ToSziltechByte(number));
        }
    }
}