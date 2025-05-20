using Mtf.HardwareKey.Enums;
using Mtf.HardwareKey.Interfaces;
using Mtf.HardwareKey.Models;
using Mtf.HardwareKey.Services;
using System;
using System.Globalization;
using System.Threading;

namespace Mtf.HardwareKey
{
    public class HardwareKey : IHardwareKey
    {
        private volatile int disposed;

        public ulong[] ApiPacket { get; private set; }

        public ushort HardwareKeyIndex { get; private set; }

        public HardwareKeyDeveloper DeveloperId { get; private set; }

        public HardwareKey(HardwareKeyDeveloper developerId, ushort hardwareKeyIndex = 0, string contactServer = null, bool autoSelect = true)
        {
            DeveloperId = developerId;
            HardwareKeyIndex = hardwareKeyIndex;
            ApiPacket = HardwareKeyPacketBuilder.Create(developerId, contactServer);
            if (autoSelect)
            {
                HardwareKeySelector.Select(this);
            }
        }

        ~HardwareKey()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Interlocked.Exchange(ref disposed, 1) != 0)
            {
                return;
            }

            if (disposing)
            {
                ReleaseManagedResources();
            }

            HardwareKeyCleanupService.Cleanup(ApiPacket);
        }

        protected virtual void ReleaseManagedResources() { }

        public ushort ReadCellValue(MemoryDataType memoryDataType)
        {
            var memoryAddress = GetMemoryAddressStoredValue(memoryDataType);
            return ReadCellValue(memoryAddress);
        }

        public ushort ReadCellValue(MemoryAddress address)
        {
            _ = SentinelAPI.Read(ApiPacket, address, out var result);
            return result;
        }

        public void WriteCellValue(MemoryAddress address, ushort data, SentinelSuperProAccessCode accessCode = SentinelSuperProAccessCode.ReadWrite)
        {
            _ = SentinelAPI.Write(ApiPacket, DeveloperId.WritePassword, address, data, accessCode);
        }

        public bool CanReadFrom(MemoryAddress address)
        {
            return SentinelAPI.CanRead(ApiPacket, address);
        }

        public void OverwriteCellValue(MemoryAddress address, ushort data)
        {
            _ = SentinelAPI.Overwrite(ApiPacket, DeveloperId.WritePassword, DeveloperId.OverwritePassword1, DeveloperId.OverwritePassword2, address, data, 0);
        }

        public byte ReadByte(MemoryAddress address, ByteType type)
        {
            var word = ReadCellValue(address);
            return type == ByteType.Higher ? (byte)(word >> 8) : (byte)(word & 0x00FF);
        }

        public void WriteBit(BitMemoryDataType bitMemoryDataType, bool bitValue)
        {
            var bitMemoryAddress = GetBitMemoryAddress(bitMemoryDataType);
            WriteBit(bitMemoryAddress, bitValue);
        }

        public void WriteBit(MemoryAddress address, Bit bit, bool bitValue)
        {
            WriteBit(new BitMemoryAddress(address, bit), bitValue);
        }

        public void WriteBit(BitMemoryAddress bitMemoryAddress, bool bitValue)
        {
            HardwareKeyBitHandler.WriteBit(DeveloperId, ApiPacket, bitMemoryAddress, bitValue);
        }

        public virtual string ReadCellValueWithNoException(MemoryAddress address)
        {
            var status = SentinelAPI.Read(ApiPacket, address, out var result);
            return status != SentinelStatusCode.Success ? status.ToString() : result.ToString(CultureInfo.InvariantCulture);
        }

        public bool IsOverwriteSucceededOrHasDataAlreadyInAddress(MemoryAddress address, ushort data)
        {
            if (ReadCellValue(address) == data)
            {
                return true;
            }

            OverwriteCellValue(address, data);
            return ReadCellValue(address) == data;
        }

        protected ushort GetMemoryAddressStoredValue(MemoryDataType memoryDataType)
        {
            return MemoryAddress.Get(DeveloperId, memoryDataType);
        }

        public BitMemoryAddress GetBitMemoryAddress(BitMemoryDataType bitMemoryDataType)
        {
            return MemoryAddress.HardwareKeyBitMaps[new Tuple<HardwareKeyDeveloper, BitMemoryDataType>(DeveloperId, bitMemoryDataType)];
        }
    };
}
