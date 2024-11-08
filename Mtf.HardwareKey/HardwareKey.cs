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

        public HardwareKey(HardwareKeyDeveloper developerId, ushort hardwareKeyIndex, string contactServer)
        {
            DeveloperId = developerId;
            HardwareKeyIndex = hardwareKeyIndex;
            ApiPacket = HardwareKeyPacketBuilder.Create(contactServer);
            HardwareKeySelector.Select(this);
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

        public ushort ReadCellValue(MemoryAddress address)
        {
            var status = SentinelAPI.RNBOsproRead(ApiPacket, address, out var result);
            StatusCodeChecker.CheckForError(status);
            return result;
        }

        public void WriteCellValue(MemoryAddress address, ushort data, SentinelSuperProAccessCode accessCode = SentinelSuperProAccessCode.ReadWrite)
        {
            var status = SentinelAPI.RNBOsproWrite(ApiPacket, DeveloperId.WritePassword, address, data, accessCode);
            StatusCodeChecker.CheckForError(status);
        }

        public bool CanReadFrom(MemoryAddress address)
        {
            var status = SentinelAPI.RNBOsproRead(ApiPacket, address, out _);
            return status == SentinelStatusCode.Success;
        }

        public void OverwriteCellValue(MemoryAddress address, ushort data)
        {
            var status = SentinelAPI.RNBOsproOverwrite(ApiPacket, DeveloperId.WritePassword, DeveloperId.OverwritePassword1, DeveloperId.OverwritePassword2, address, data, 0);
            StatusCodeChecker.CheckForError(status);
        }

        public byte ReadByte(MemoryAddress address, ByteType type)
        {
            var word = ReadCellValue(address);
            return type == ByteType.Higher ? (byte)(word >> 8) : (byte)(word & 0x00FF);
        }

        public void WriteBit(MemoryAddress address, Bit bit, bool bitValue)
        {
            HardwareKeyBitHandler.WriteBit(DeveloperId, ApiPacket, new BitMemoryAddress(address, bit), bitValue);
        }

        public virtual string ReadCellValueWithNoException(MemoryAddress address)
        {
            var status = SentinelAPI.RNBOsproRead(ApiPacket, address, out var result);
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

        protected BitMemoryAddress GetBitMemoryAddress(BitMemoryDataType bitMemoryDataType)
        {
            return MemoryAddress.HardwareKeyBitMaps[(DeveloperId, bitMemoryDataType)];
        }
    };
}
