using Mtf.HardwareKey.Exceptions;
using Mtf.HardwareKey.Interfaces;
using Mtf.HardwareKey.Models;
using System;

namespace Mtf.HardwareKey.Services
{
    public static class HardwareKeyCracker
    {
        public static ushort FindDeveloperId()
        {
            ushort developerId = 0;
            var found = false;

            var apiPacket = HardwareKeyPacketBuilder.Create(developerId);

            try
            {
                while (developerId < UInt16.MaxValue)
                {
                    var status = SentinelAPI.FindFirstUnit(apiPacket, developerId);
                    if (status == SentinelStatusCode.Success)
                    {
                        found = true;
                        break;
                    }
                    developerId++;
                }
            }
            finally
            {
                HardwareKeyCleanupService.Cleanup(apiPacket);
            }

            return found ? developerId : throw new DongleNotFoundException();
        }

        public static ushort BruteForceDeveloperId(ulong[] apiPacket)
        {
            SentinelStatusCode status;
            ushort developerId = 1;

            do
            {
                status = SentinelAPI.FindFirstUnit(apiPacket, developerId++);
            }
            while (status != SentinelStatusCode.Success && developerId < ushort.MaxValue);
            return developerId;
        }

        public static bool IsWriteSucceeded(IHardwareKey hardwareKey, ulong[] apiPacket, MemoryAddress address, ushort writePassword)
        {
            if (hardwareKey == null)
            {
                throw new ArgumentNullException(nameof(hardwareKey));
            }

            var originalData = hardwareKey.ReadCellValue(address);
            var data = originalData == UInt16.MaxValue ? (ushort)(originalData - 1) : (ushort)(originalData + 1);

            _ = SentinelAPI.Write(apiPacket, writePassword, address, data, 0);

            hardwareKey.WriteCellValue(address, data);
            if (hardwareKey.ReadCellValue(address) == originalData)
            {
                return false;
            }

            _ = SentinelAPI.Write(apiPacket, writePassword, address, originalData, 0);
            return hardwareKey.ReadCellValue(address) == originalData;
        }

        /// <summary>
        /// Kills the dongle??? Or writes over the write password? - DO NOT USE THIS FUNCTION
        /// </summary>
        /// <param name="hardwareKey">The hardware key.</param>
        /// <param name="address">The cell memory address to write.</param>
        /// <returns>The found Write password.</returns>
        /// <exception cref="ArgumentNullException">When hardwareKey is null.</exception>
        /// <exception cref="WritePasswordNotFoundException">When all possible write password has been tried, and the write was unsuccessful.</exception>
        public static ushort FindWritePassword(IHardwareKey hardwareKey, MemoryAddress address)
        {
            if (hardwareKey == null)
            {
                throw new ArgumentNullException(nameof(hardwareKey));
            }

            var writePassword = UInt16.MinValue;
            HardwareKeySelector.Select(hardwareKey);

            try
            {
                while (writePassword < UInt16.MaxValue)
                {
                    if (IsWriteSucceeded(hardwareKey, hardwareKey.ApiPacket, address, writePassword))
                    {
                        return writePassword;
                    }

                    writePassword++;
                }

                throw new WritePasswordNotFoundException();
            }
            finally
            {
                hardwareKey.Dispose();
            }
        }
    }
}
