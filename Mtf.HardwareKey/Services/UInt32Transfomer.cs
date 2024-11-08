using System;

namespace Mtf.HardwareKey.Services
{
    public static class UInt32Transfomer
    {
        public static ushort ToSziltechByte(int number)
        {
            return number > 100
                ? Convert.ToUInt16(Math.Round((97 + Math.Pow(number - 97, 1.6807)) / 5) * 5)
                : (ushort)number;
        }
    }
}
