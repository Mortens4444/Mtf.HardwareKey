﻿using Mtf.HardwareKey.Enums;
using Mtf.HardwareKey.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Mtf.HardwareKey.Models
{
    public sealed class MemoryAddress
    {
        public static readonly SortedList<ushort, MemoryAddress> Values = new SortedList<ushort, MemoryAddress>();

        public const ushort MaxAddress = 255;

        public static Dictionary<Tuple<HardwareKeyDeveloper, BitMemoryDataType>, BitMemoryAddress> HardwareKeyBitMaps => new Dictionary<Tuple<HardwareKeyDeveloper, BitMemoryDataType>, BitMemoryAddress>
        {
            { new Tuple<HardwareKeyDeveloper, BitMemoryDataType>(HardwareKeyDeveloper.Test1, BitMemoryDataType.LicenseBit), new BitMemoryAddress(Get(HardwareKeyDeveloper.Test1, MemoryDataType.License), Bit._01) },
        };

        private static readonly Dictionary<Tuple<HardwareKeyDeveloper, ushort>, MemoryDataType> hardwareKeyMaps = new Dictionary<Tuple<HardwareKeyDeveloper, ushort>, MemoryDataType>
        {
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0x00), MemoryDataType.SafeNetKeySerialNumber },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0x01), MemoryDataType.SafeNetDeveloperId },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0x02), MemoryDataType.SafeNetOverwritePassword1 },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0x03), MemoryDataType.SafeNetOverwritePassword2 },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0x04), MemoryDataType.SafeNetWritePassword },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0x05), MemoryDataType.SafeNetHardLicenseLimit },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0x06), MemoryDataType.SafeNetC6 },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0x07), MemoryDataType.SafeNet },

            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0x0A), MemoryDataType.License },

            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0xF0), MemoryDataType.SafeNet },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0xF1), MemoryDataType.SafeNet },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0xF2), MemoryDataType.SafeNet },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0xF3), MemoryDataType.SafeNet },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0xF4), MemoryDataType.SafeNet },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0xF5), MemoryDataType.SafeNet },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0xF6), MemoryDataType.SafeNet },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0xF7), MemoryDataType.SafeNet },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0xF8), MemoryDataType.SafeNet },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0xF9), MemoryDataType.SafeNet },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0xFA), MemoryDataType.SafeNet },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0xFB), MemoryDataType.SafeNet },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0xFC), MemoryDataType.SafeNet },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0xFD), MemoryDataType.SafeNet },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0xFE), MemoryDataType.SafeNet },
            { new Tuple<HardwareKeyDeveloper, ushort>(HardwareKeyDeveloper.Test1, 0xFF), MemoryDataType.SafeNet }
        };

        /// <summary>
        /// 0x00: SafeNet Key Serial Number
        /// </summary>
        public static readonly MemoryAddress SafeNet_KeySerialNumber = new MemoryAddress(0, "0x00: SafeNet Key Serial Number");

        /// <summary>
        /// 0x01: SafeNet Developer Id
        /// </summary>
        public static readonly MemoryAddress SafeNet_DeveloperId = new MemoryAddress(1, "0x01: SafeNet Developer Id");

        /// <summary>
        /// 0x02: SafeNet Overwrite Password1
        /// </summary>
        public static readonly MemoryAddress SafeNet_OverwritePassword1 = new MemoryAddress(2, "0x02: SafeNet Overwrite Password1");

        /// <summary>
        /// 0x03: SafeNet Overwrite Password2
        /// </summary>
        public static readonly MemoryAddress SafeNet_OverwritePassword2 = new MemoryAddress(3, "0x03: SafeNet Overwrite Password2");

        /// <summary>
        /// 0x04: SafeNet Write Password
        /// </summary>
        public static readonly MemoryAddress SafeNet_WritePassword = new MemoryAddress(4, "0x04: SafeNet Write Password");

        /// <summary>
        /// 0x05: SafeNet Hard License Limit
        /// </summary>
        public static readonly MemoryAddress SafeNet_HardLicenseLimit = new MemoryAddress(5, "0x05: SafeNet Hard License Limit");

        /// <summary>
        /// 0x06: SafeNet C6
        /// </summary>
        public static readonly MemoryAddress SafeNet_C6 = new MemoryAddress(6, "0x06: SafeNet C6");

        /// <summary>
        /// 0x07: SafeNet
        /// </summary>
        public static readonly MemoryAddress SafeNet = new MemoryAddress(7, "0x07: SafeNet");

        static MemoryAddress()
        {
            for (ushort address = 8; address <= 255; address++)
            {
                _ = new MemoryAddress(address, String.Concat("0x", address.ToString("X", CultureInfo.InvariantCulture)));
            }
        }

        private readonly ushort address;
        private readonly string description;

        private MemoryAddress(ushort address, string description)
        {
            this.address = address;
            this.description = description;
            Values.Add(address, this);
        }
        
        public static MemoryDataType GetDataType(HardwareKeyDeveloper hardwareKeyType, ushort address)
        {
            return address > MaxAddress ? throw new ArgumentOutOfRangeException(nameof(address))
                : address >= 240 ? MemoryDataType.SafeNet
                : hardwareKeyMaps.TryGetValue(Tuple.Create(hardwareKeyType, address), out var dataType) ? dataType
                : MemoryDataType.Unknown;
        }

        public static implicit operator MemoryAddress(ushort address)
        {
            return Values.TryGetValue(address, out var memoryAddresss) ? memoryAddresss : throw new InvalidMemoryAddressException($"Not a valid memory address: {address}");
        }

        public static implicit operator ushort(MemoryAddress memoryAddresss)
        {
            return memoryAddresss.address;
        }

        public override string ToString() => $"{address}: {description}";

        public static ushort Get(HardwareKeyDeveloper developer, MemoryDataType memoryDataType)
        {
            return GetAll(developer, memoryDataType).Single();
        }

        public static IList<ushort> GetAll(HardwareKeyDeveloper developer, MemoryDataType memoryDataType)
        {
            return hardwareKeyMaps
                .Where(entry => entry.Key.Item1 == developer && entry.Value == memoryDataType)
                .Select(entry => entry.Key.Item2)
                .ToList();
        }
    }
}
