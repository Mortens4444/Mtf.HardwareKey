using Mtf.HardwareKey.Enums;
using Mtf.HardwareKey.Interfaces;
using Mtf.HardwareKey.Models;
using System;

namespace Mtf.HardwareKey.Services
{
    public static class HardwareKeyBitHandler
    {
        public static ushort ReadCellValue(IHardwareKey hardwareKey, MemoryAddress address, Bit from, Bit to)
        {
            return hardwareKey == null ? throw new ArgumentNullException(nameof(hardwareKey))
                : ReadCellValue(hardwareKey.ReadCellValue(address), from, to);
        }

        public static ushort ReadCellValue(ushort value, Bit from, Bit to)
        {
            var fromInt = (int)from;
            var toInt = (int)to;

            if (toInt < fromInt)
            {
                (fromInt, toInt) = (toInt, fromInt);
            }

            var mask = (ushort)(((1 << (toInt - fromInt + 1)) - 1) << fromInt);
            return (ushort)(value & mask);
        }

        public static bool IsBitSet(ulong[] apiPacket, BitMemoryAddress bitMemoryAddress)
        {
            return bitMemoryAddress == null
                ? throw new ArgumentNullException(nameof(bitMemoryAddress))
                : IsBitSet(apiPacket, bitMemoryAddress.MemoryAddress, bitMemoryAddress.Bit);
        }

        private static bool IsBitSet(ulong[] apiPacket, ushort address, Bit bit)
        {
            _ = SentinelAPI.Read(apiPacket, address, out var value);
            var mask = (ushort)(1 << (15 - (int)bit));
            return (value & mask) != 0;
        }

        //public static bool IsBitSet(IHardwareKey hardwareKey, MemoryAddress address, Bit bit)
        //{
        //    if (hardwareKey == null)
        //    {
        //        throw new ArgumentNullException(nameof(hardwareKey));
        //    }
        //    var word = hardwareKey.ReadCellValue(address);
        //    return (word & (int)Math.Pow(2, (byte)bit)) != 0;
        //}

        public static void WriteBit(HardwareKeyDeveloper developerId, ulong[] apiPacket, BitMemoryAddress bitMemoryAddress, bool bitValue)
        {
            if (developerId == null)
            {
                throw new ArgumentNullException(nameof(developerId));
            }
            if (bitMemoryAddress == null)
            {
                throw new ArgumentNullException(nameof(bitMemoryAddress));
            }
            WriteBit(developerId, apiPacket, bitMemoryAddress.MemoryAddress, bitMemoryAddress.Bit, bitValue);
        }

        private static void WriteBit(HardwareKeyDeveloper developerId, ulong[] apiPacket, ushort address, Bit bit, bool bitValue)
        {
            _ = SentinelAPI.Read(apiPacket, address, out var value);

            var mask = (ushort)(1 << (15 - (int)bit));

            value = bitValue ? (ushort)(value | mask) : (ushort)(value & ~mask);

            _ = SentinelAPI.Write(apiPacket, developerId.WritePassword, address, value, 0);
        }
    }
}
