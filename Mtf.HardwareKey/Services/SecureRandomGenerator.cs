using System;
using System.Security.Cryptography;

namespace Mtf.HardwareKey.Services
{
    public static class SecureRandomGenerator
    {
        public static int GetInt(int minValue, int maxValue)
        {
            if (maxValue < minValue)
            {
                (minValue, maxValue) = (maxValue, minValue);
            }
            var range = maxValue - minValue;

            var uint32Buffer = new byte[4];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(uint32Buffer);
                var randomValue = BitConverter.ToUInt32(uint32Buffer, 0);
                return (int)(minValue + (randomValue % range));
            }
        }
    }
}
