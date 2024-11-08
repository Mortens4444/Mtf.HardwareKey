using Mtf.HardwareKey.Enums;

namespace Mtf.HardwareKey.Models
{
    public class BitMemoryAddress
    {
        public MemoryAddress MemoryAddress { get; }

        public Bit Bit { get; }

        public BitMemoryAddress(MemoryAddress memoryAddress, Bit bit)
        {
            MemoryAddress = memoryAddress;
            Bit = bit;
        }
    }
}
