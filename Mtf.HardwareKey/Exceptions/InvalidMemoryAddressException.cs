using System;

namespace Mtf.HardwareKey.Exceptions
{
    public class InvalidMemoryAddressException : Exception
    {
        public InvalidMemoryAddressException(string message) : base(message) { }
    }
}
