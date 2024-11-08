using System;
using System.Globalization;

namespace Mtf.HardwareKey.Extensions
{
    public static class UInt16Extensions
    {
        public static string ToHexString(this UInt16 value)
        {
            return value.ToString("x4", CultureInfo.InvariantCulture).ToUpper(CultureInfo.CurrentCulture);
        }
    }
}
