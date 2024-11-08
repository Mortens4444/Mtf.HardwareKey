using Mtf.HardwareKey.Enums;
using Mtf.HardwareKey.Extensions;

namespace Mtf.HardwareKey.UnitTests.Extensions
{
    [TestFixture]
    public class ObjectExtensionsTests
    {
        [Test]
        public void GetDescription_ShouldReturnDescription_ForEnumWithDescription()
        {
            var description = KeyFamily.SuperPro.GetDescription();
            Assert.That(description, Is.EqualTo("SSP"));
        }

        [Test]
        public void GetDescription_ShouldReturnName_ForEnumWithoutDescription()
        {
            var description = Bit._00_LSB.GetDescription();
            Assert.That(description, Is.EqualTo("_00_LSB"));
        }

        [Test]
        public void GetDescription_ShouldReturnName_ForFieldWithoutDescription()
        {
            var description = "UnknownField".GetDescription();
            Assert.That(description, Is.EqualTo("UnknownField"));
        }

        [Test]
        public void GetDescription_ShouldThrowArgumentNullException_WhenValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => ObjectExtensions.GetDescription(null));
        }
    }
}