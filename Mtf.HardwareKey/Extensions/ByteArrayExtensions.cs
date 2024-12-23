﻿namespace Mtf.HardwareKey.Extensions
{
    public static class ByteArrayExtensions
    {
        public static bool IsEqual(byte[] array1, byte[] array2)
        {
            if ((array1 == null) && (array2 == null))
            {
                return true;
            }

            if ((array1 == null) || (array2 == null))
            {
                return false;
            }

            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (var i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
