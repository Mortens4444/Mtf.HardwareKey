using Mtf.HardwareKey.Enums;
using Mtf.HardwareKey.Services;

namespace Mtf.HardwareKey.UnitTests.Services
{
    [TestFixture]
    public class HardwareKeyBitHandlerTests
    {
        [TestCase((ushort)830, Bit._11, Bit._08, 768)]
        [TestCase((ushort)830, Bit._00_MSB, Bit._07, 62)]
        public void Test(ushort number, Bit from, Bit to, int expectedResult)
        {
            var actualResult = HardwareKeyBitHandler.ReadCellValue(number, from, to);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
