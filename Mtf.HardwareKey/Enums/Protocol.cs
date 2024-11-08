using System;

namespace Mtf.HardwareKey.Enums
{
    [Flags]
    public enum Protocol
    {
        TCP = 1,
        IPX = 2,
        NetBEUI = 4
    }
}
