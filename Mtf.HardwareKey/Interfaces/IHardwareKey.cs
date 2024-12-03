using Mtf.HardwareKey.Enums;
using Mtf.HardwareKey.Models;
using System;

namespace Mtf.HardwareKey.Interfaces
{
    public interface IHardwareKey : IDisposable
    {
        ulong[] ApiPacket { get; }

        ushort HardwareKeyIndex { get; }

        HardwareKeyDeveloper DeveloperId { get; }

        ushort ReadCellValue(MemoryAddress address);

        void WriteBit(BitMemoryAddress bitMemoryAddress, bool bitValue);

        void WriteBit(BitMemoryDataType bitMemoryDataType, bool bitValue);

        void WriteBit(MemoryAddress address, Bit bit, bool bitValue);

        void WriteCellValue(MemoryAddress address, ushort data, SentinelSuperProAccessCode accessCode = SentinelSuperProAccessCode.ReadWrite);

        void OverwriteCellValue(MemoryAddress address, ushort data);
    }
}
